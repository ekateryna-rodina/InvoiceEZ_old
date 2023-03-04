using InvoiceEZ.Domain.Models;

namespace InvoiceEZ.UnitTests.Utils;

public static class TestCaseUtils
{
     private static List<(int, decimal)> cases = new List<(int, decimal)>(){
        (3, 5100.0m), (2, 24460.5m), (4, 1200.0m), (1, 2405.3m)
    };

    private static List<Invoice> _seedInvoices = new List<Invoice>();
    private static List<object[]> _getTotalCaseParams = new List<object[]>();

    static TestCaseUtils(){
        InitTotalTestCasesData();
    }

    private static void InitTotalTestCasesData()
    {
        foreach(var (id, total) in cases){   
            // seed data 
            _seedInvoices.Add(new Invoice(){
                Id = id,
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
}