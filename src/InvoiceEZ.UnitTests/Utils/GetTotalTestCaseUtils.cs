using InvoiceEZ.Domain.Models;
using InvoiceEZ.Shared.MockData;

namespace InvoiceEZ.UnitTests.Utils;

public static class GetTotalTestCaseUtils
{
    private static List<object[]> _getTotalCaseParams = new List<object[]>();

    static GetTotalTestCaseUtils(){
        InitTotalTestCasesData();
    }

    private static void InitTotalTestCasesData()
    {
        _getTotalCaseParams = Invoices.Total.ResultTestCases
                .Select(i => new object[] { i.Key, i.Value }).ToList();

    }

    public static IEnumerable<object[]> TotalCaseParams {
        get { return _getTotalCaseParams.AsEnumerable(); }
    }
}