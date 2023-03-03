using System;
namespace InvoiceEZ.Domain.Models
{
	public class Invoice
	{
        public Invoice()
        {
            InvoiceItems = new List<InvoiceItem>();
        }
        // A unique numerical identifier of an invoice (mandatory)
        public int Id { get; set; }
        // A short description of an invoice (optional).
        public string Description { get; set; } = default!;
        // A number of an invoice e.g. 134/10/2018 (mandatory).
        public string Number { get; set; } = default!;
        // An issuer of an invoice e.g. Metz-Anderson, 600 Hickman Street,Illinois (mandatory).
        public string Seller { get; set; } = default!;
        // A buyer of a service or a product e.g. John Smith, 4285 Deercove Drive, Dallas (mandatory).
        public string Buyer { get; set; } = default!;
        // A date when an invoice was issued (mandatory).
        public DateTime CreationDate { get; set; }
        // A date when an invoice was paid (optional).
        public DateTime? AcceptanceDate { get; set; }
        // A collection of invoice items for a given invoice (can be empty but is never null).
        public IList<InvoiceItem> InvoiceItems { get; }
    }
}


