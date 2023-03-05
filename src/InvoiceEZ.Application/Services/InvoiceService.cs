using InvoiceEZ.Application.Contracts;
using InvoiceEZ.Application.Helpers;

namespace InvoiceEZ.Domain.Repositories
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public OperationResult<IReadOnlyDictionary<string, long>> GetItemsReport(DateTime? from, DateTime? to)
        {
            try
            {
                IReadOnlyDictionary<string, long> itemsReport = _invoiceRepository.GetItemsReport(from, to);
                return OperationResult<IReadOnlyDictionary<string, long>>.CreateSuccess(itemsReport);
            }
            catch (Exception ex)
            {
                return OperationResult<IReadOnlyDictionary<string, long>>.CreateFailure(new List<Exception> { ex });
            }
        }

        public OperationResult<decimal?> GetTotal(int invoiceId)
        {
            try
            {
                var total = _invoiceRepository.GetTotal(invoiceId);
                return OperationResult<decimal?>.CreateSuccess(total);
            }
            catch (Exception ex)
            {
                return OperationResult<decimal?>.CreateFailure(new List<Exception> { ex });
            }
        }

        public OperationResult<decimal> GetTotalOfUnpaid()
        {
            try
            {
                var total = _invoiceRepository.GetTotalOfUnpaid();
                return OperationResult<decimal>.CreateSuccess(total);
            }
            catch (Exception ex)
            {
                return OperationResult<decimal>.CreateFailure(new List<Exception> { ex });
            }
        }
    }
}