namespace InvoiceEZ.Domain.Repositories
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public IReadOnlyDictionary<string, long> GetItemsReport(DateTime? from, DateTime? to)
        {
            return _invoiceRepository.GetItemsReport(from, to);
        }

        public decimal? GetTotal(int invoiceId)
        {
            return _invoiceRepository.GetTotal(invoiceId);
        }

        public decimal GetTotalOfUnpaid()
        {
            return _invoiceRepository.GetTotalOfUnpaid();
        }
    }
}