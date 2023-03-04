using System;
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
            throw new NotImplementedException();
        }

        public decimal? GetTotal(int invoiceId)
        {
            decimal? total;
            var invoice = _invoices.FirstOrDefault(i => i.Id == invoiceId);
            if (invoice == null) {
                return null;
            }

            total = invoice.InvoiceItems?.Sum(item => item.Price * item.Count) ?? 0;
            return total;
        }

        public decimal GetTotalOfUnpaid()
        {
            throw new NotImplementedException();
        }
    }
}

