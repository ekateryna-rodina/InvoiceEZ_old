using InvoiceEZ.Domain.Models;

namespace InvoiceEZ.UnitTests.Utils;

public static class GetTotalTestCaseUtils
{
     private static List<(int, decimal)> _invoiceTotalCases = new List<(int, decimal)>(){
        (3, 5100.0m), (2, 24460.5m), (4, 1200.0m), (1, 2405.3m)
    };

    private static List<(DateTime?, DateTime?, List<Invoice>, Dictionary<string, long>)> _invoiceReports = 
                new List<(DateTime?, DateTime?, List<Invoice>, Dictionary<string, long>)>(){
        (null, null, new List<Invoice>(){new Invoice(){Id = 5, InvoiceItems = new List<InvoiceItem>(){new InvoiceItem(){Name = "eggs", Count = 9800}}}},  new Dictionary<string, long>{{"eggs", 9800}})
    };

    public const decimal UNPAID_TOTAL = 5000.0m;

    private static List<Invoice> _seedInvoices = new List<Invoice>();
    private static List<object[]> _getTotalCaseParams = new List<object[]>();

    static GetTotalTestCaseUtils(){
        InitTotalTestCasesData();
    }

    private static void InitTotalTestCasesData()
    {
        foreach(var (id, total) in _invoiceTotalCases){   
            // seed data 
            _seedInvoices.Add(new Invoice(){
                Id = id,
                AcceptanceDate = DateTime.Now.AddDays(-3),
                
                InvoiceItems = new List<InvoiceItem>(){
                    new InvoiceItem { Count = 2, Price = total / 2},
                }
            });

            // case params
            var caseParams = new object[] { id, total };
            _getTotalCaseParams.Add(caseParams);
        }
    }

    public static IEnumerable<object[]> TotalCaseParams {
        get { return _getTotalCaseParams.AsEnumerable(); }
    }

    public static IEnumerable<Invoice> SeedInvoices {
        get { return _seedInvoices.AsEnumerable(); }
    }

    public static IEnumerable<Invoice> SeedInvoicesIncludingUnpaid {
        get { 
                var allInvoices = new List<Invoice>(_seedInvoices);
                allInvoices.Add(new Invoice(){
                    Id = 10, 
                    InvoiceItems = new List<InvoiceItem>(){
                        new InvoiceItem { Count = 2, Price = UNPAID_TOTAL / 2},
                    }
                });

                return allInvoices;
            }
    }
}