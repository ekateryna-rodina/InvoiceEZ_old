using System;
namespace InvoiceEZ.API
{
	public class APIRoutes
	{
        public const string BaseRoute = "api/invoice/";
        public static class Invoice
        {
            public const string ItemsReport = BaseRoute + "itemsreport";
            public const string TotalByInvoiceId = BaseRoute + "total/{id}";
            public const string TotalUnpaid = BaseRoute + "totalunpaid";
        }
    }
}

