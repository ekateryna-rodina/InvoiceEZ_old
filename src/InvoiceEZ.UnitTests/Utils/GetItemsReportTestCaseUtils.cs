using InvoiceEZ.Domain.Models;

namespace InvoiceEZ.UnitTests.Utils;

public static class GetReportTestCaseUtils
{
     private static List<object?[]> _itemReportsInvoiceExist = new List<object?[]>();
     private static List<object?[]> _itemReportsNoInvoice = new List<object?[]>();
    static GetReportTestCaseUtils(){
        InitReportWithInvoicesTestCasesData();
        InitReportWithNoInvoicesTestCasesData();
    }
    private static void InitReportWithInvoicesTestCasesData(){
        for(var i = 0; i < ItemsReportData.RangeInvoiceExistCases.Count; i++){
            var testCase = new object?[]{
                    ItemsReportData.RangeInvoiceExistCases[i].Item1, 
                    ItemsReportData.RangeInvoiceExistCases[i].Item2,
                    ItemsReportData.InvoicesInTheRangeTestCases[i],
                    ItemsReportData.ResultInvoceExistTestCases[i]
                 };
            _itemReportsInvoiceExist.Add(testCase);
        }
    }

    private static void InitReportWithNoInvoicesTestCasesData(){
        for(var i = 0; i < ItemsReportData.RangeNoInvoiceCases.Count; i++){
            var testCase = new object?[]{
                    ItemsReportData.RangeNoInvoiceCases[i].Item1, 
                    ItemsReportData.RangeNoInvoiceCases[i].Item2,
                    ItemsReportData.InvoicesOutOfRangeTestCases[i],
                 };
            _itemReportsNoInvoice.Add(testCase);
        }
    }
  
    public static IEnumerable<object?[]> ItemReportsInvoiceExistCaseParams {
        get { return _itemReportsInvoiceExist.AsEnumerable(); }
    }

    public static IEnumerable<object?[]> ItemReportsNoInvoiceCaseParams {
        get { return _itemReportsNoInvoice.AsEnumerable(); }
    }
}