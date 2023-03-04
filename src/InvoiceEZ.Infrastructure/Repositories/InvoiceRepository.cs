using InvoiceEZ.Domain.Models;
using InvoiceEZ.Domain.Repositories;

namespace InvoiceEZ.Infrastructure.Repositories
{
	public class InvoiceRepository : IInvoiceRepository
	{
        private readonly IQueryable<Invoice> _invoices;

        public InvoiceRepository(IQueryable<Invoice> invoices)
		{
            if (invoices == null)
            {
                throw new ArgumentNullException();
            }

            _invoices = invoices;
        }
        public IReadOnlyDictionary<string, long> GetItemsReport(DateTime? from, DateTime? to)
        {
            if (from != null && to != null && DateTime.Compare((DateTime)from, (DateTime)to) > 0) 
            {
                Console.WriteLine("Invalid range: from date is greated than to");
            }

            // filter invoices by creation date if from or to dates are specified
            var items = _invoices
                    .Where(i => from == null || i.CreationDate >= from)
                    .Where(i => to == null || i.CreationDate <= to)
                        .SelectMany(i => i.InvoiceItems);
            var result = items.GroupBy(item => item.Name)
                .ToDictionary(g => g.Key, g => g.Sum(item => item.Count));
            return result;
        }
        public decimal? GetTotal(int invoiceId)
        {
            // Note that some of the tests provided use negative IDs for invoices, but in a real-life application, 
            // it's generally not recommended to allow IDs that are less than or equal to zero for invoices, unless there are specific requirements or constraints that mandate it.
            if(invoiceId <= 0){
                Console.WriteLine("Input cannot be negative or 0");
            }
            decimal? total;
            var invoice = _invoices.FirstOrDefault(i => i.Id == invoiceId);
            if (invoice == null) {
                return null;
            }

            total = invoice.InvoiceItems.Sum(item => item.Price * item.Count);
            return total;
        }

        public decimal GetTotalOfUnpaid()
        {
            var total = _invoices.Where(i => i.AcceptanceDate == null)
                .Sum(i => i.InvoiceItems.Sum(item => item.Price*item.Count));
            return total;
        }
    }
}

