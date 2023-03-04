namespace InvoiceEZ.Domain.Repositories
{
	public interface IInvoiceService {
        /// <summary>
        /// Calculates total price of all items listed in the invoice.
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns>
        /// The total price of all items listed in the invoice as a nullable decimal value.
        /// Returns null if the invoice is not found.
        /// </returns>
        decimal? GetTotal(int invoiceId);
        /// <summary>
        /// Calculates total price of all items which belong to unpaid invoices.
        /// </summary>
        /// <returns>
        /// The total price of all items listed in the unpaid invoices.
        /// </returns>
        decimal GetTotalOfUnpaid();
        /// <summary>
        /// Generates a report of all items purchased, including their names and quantities.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns>
        /// Should return a dictionary where the name of an invoice item is a key and the number of purchased
        /// items is a value.
        /// The number of bought items should be summed within a given period of time (from, to). Both the
        /// from date and the end date can be null.
        /// </returns>
        /// <exception cref="">Thrown when the argumentt from is greater than argument to</exception>
        IReadOnlyDictionary<string, long> GetItemsReport(DateTime? from, DateTime? to);
    }
}