
using InvoiceEZ.Shared.MockData;

namespace InvoiceEZ.UnitTests.Utils;

public static class GetReportTestCaseUtils
{
    private static List<object?[]> _invoiceExistTestParams = new List<object?[]>();
    private static List<object?[]> _noInvoiceTestParams = new List<object?[]>();
    static GetReportTestCaseUtils()
    {
        InitReportWithInvoicesTestCases();
        InitReportWithNoInvoicesTestCases();
    }
    private static void InitReportWithInvoicesTestCases()
    {
        for (var i = 0; i < Invoices.ItemsReport.RangeInvoiceExistCases.Count; i++)
        {
            var testCase = new object?[]{
                    Invoices.ItemsReport.RangeInvoiceExistCases[i].Item1,
                    Invoices.ItemsReport.RangeInvoiceExistCases[i].Item2,
                    Invoices.ItemsReport.InvoicesInTheRangeTestCases[i],
                    Invoices.ItemsReport.ResultInvoceExistTestCases[i]
                 };
            _invoiceExistTestParams.Add(testCase);
        }
    }

    private static void InitReportWithNoInvoicesTestCases()
    {
        for (var i = 0; i < Invoices.ItemsReport.RangeNoInvoiceCases.Count; i++)
        {
            var testCase = new object?[]{
                    Invoices.ItemsReport.RangeNoInvoiceCases[i].Item1,
                    Invoices.ItemsReport.RangeNoInvoiceCases[i].Item2,
                    Invoices.ItemsReport.InvoicesOutOfRangeTestCases[i],
                 };
            _noInvoiceTestParams.Add(testCase);
        }
    }

    public static IEnumerable<object?[]> ItemReportsInvoiceExistCaseParams
    {
        get { return _invoiceExistTestParams.AsEnumerable(); }
    }

    public static IEnumerable<object?[]> ItemReportsNoInvoiceCaseParams
    {
        get { return _noInvoiceTestParams.AsEnumerable(); }
    }
}