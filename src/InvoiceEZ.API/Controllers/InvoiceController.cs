using InvoiceEZ.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace InvoiceEZ.API.Controllers
{
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet(APIRoutes.Invoice.TotalByInvoiceId)]
        public ActionResult<decimal> GetTotal(int id)
        {
            var result = _invoiceService.GetTotal(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet(APIRoutes.Invoice.TotalUnpaid)]
        public ActionResult<decimal> GetTotalOfUnpaid()
        {
            var result = _invoiceService.GetTotalOfUnpaid();
            return Ok(result);
        }

        [HttpGet(APIRoutes.Invoice.ItemsReport)]
        public ActionResult<IReadOnlyDictionary<string, long>> GetItemsReport(DateTime? from, DateTime? to)
        {
            try
            {
                var result = _invoiceService.GetItemsReport(from, to);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
