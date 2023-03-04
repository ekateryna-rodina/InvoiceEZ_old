using Moq;
using InvoiceEZ.Domain.Models;
using InvoiceEZ.Infrastructure.Repositories;
using FluentAssertions;
using InvoiceEZ.UnitTests.Utils;

namespace InvoiceEZ.UnitTests;

public class InvoiceRepositoryTests
{
    private Mock<IQueryable<Invoice>> _mockInvoices = new Mock<IQueryable<Invoice>>();

    [Test]
    public void Constructor_NullInputParameter_ExceptionShouldBeThrown(){
        // Arrange
        IQueryable<Invoice>? invoices = null;
        // warning is by design in this case because constuctor param is not nullable
        Action act = () => new InvoiceRepository(invoices); 

        // Act & Assert
        act.Should().Throw<ArgumentNullException>();
    }

    // Using TestCaseSource is a workaround to allow decimal as a parameter for TestCaseAttribute
    [Test, TestCaseSource(typeof(GetTotalTestCaseUtils), nameof(GetTotalTestCaseUtils.TotalCaseParams))]
    [TestCase(Int32.MinValue)]
    [TestCase(Int32.MaxValue)]
    [TestCase(5)]
    [TestCase(-1)]
    public void GetTotal_InvoicesExist_CorrectValueShouldBeReturned(int input, decimal? output = null)
    {
        var invoices = GetTotalTestCaseUtils.SeedInvoices;
        SeedInvoiceRepository(invoices);
        var repository = new InvoiceRepository(_mockInvoices.Object);

        // Act
        var result = repository.GetTotal(input);

        // Assert
        result.Should().Be(output);
    }

    [Test]
    [TestCase(4)]
    [TestCase(3)]
    [TestCase(Int32.MaxValue)]
    [TestCase(Int32.MinValue)]
    [TestCase(2)]
    [TestCase(1)]
    [TestCase(-1)]
    [TestCase(5)]
    public void GetTotal_NoInvoices_NullShouldBeReturned(int input, decimal? output = null)
    {
       // Arrange
       SeedInvoiceRepository(new List<Invoice>());
       var repository = new InvoiceRepository(_mockInvoices.Object);

       // Act
       var result = repository.GetTotal(input);

       // Assert
       result.Should().BeNull();
    }

    [Test]
    public void GetTotalOfUnpaid_NoInvoices_ZeroShouldBeReturned(){
        // Arrange
        var invoices = GetTotalTestCaseUtils.SeedInvoices;
        SeedInvoiceRepository(invoices);
        var repository = new InvoiceRepository(_mockInvoices.Object);

       // Act
       var result = repository.GetTotalOfUnpaid();

       // Assert
       result.Should().Be(0);
    }

    [Test]
    public void GetTotalOfUnpaid_InvoicesExist_CorrectValueShouldBeReturned(){
        // Arrange
        var invoices = GetTotalTestCaseUtils.SeedInvoicesIncludingUnpaid;
       SeedInvoiceRepository(invoices);
       var repository = new InvoiceRepository(_mockInvoices.Object);

       // Act
       var result = repository.GetTotalOfUnpaid();

       // Assert
       result.Should().Be(GetTotalTestCaseUtils.UNPAID_TOTAL);
    }

    [Test, TestCaseSource(typeof(GetReportTestCaseUtils), nameof(GetReportTestCaseUtils.ItemReportsInvoiceExistCaseParams))]
    public void GetItemsReport_InvoicesExist_CorrectReportShouldBeReturned(DateTime? from, DateTime? to, List<Invoice> invoices, Dictionary<string, long> output){
        // Arrange
       SeedInvoiceRepository(invoices);
       var repository = new InvoiceRepository(_mockInvoices.Object);

       // Act
       var result = repository.GetItemsReport(from, to);

       // Assert
       result.Should().NotBeNull();
       result.Should().BeEquivalentTo(output);
    }

    [Test, TestCaseSource(typeof(GetReportTestCaseUtils), nameof(GetReportTestCaseUtils.ItemReportsNoInvoiceCaseParams))]
    public void GetItemsReport_NoInvoices_EmptyReportShouldBeReturned(DateTime? from, DateTime? to, List<Invoice> invoices){
        // Arrange
       SeedInvoiceRepository(invoices);
       var repository = new InvoiceRepository(_mockInvoices.Object);

       // Act
       var result = repository.GetItemsReport(from, to);

       // Assert
       result.Should().NotBeNull();
       result.Should().BeEquivalentTo(new Dictionary<string, long>());
    }

    private void SeedInvoiceRepository(IEnumerable<Invoice> invoices) {
        _mockInvoices.Setup(i => i.GetEnumerator()).Returns(invoices.GetEnumerator());
        _mockInvoices.Setup(i => i.Provider).Returns(invoices.AsQueryable().Provider);
        _mockInvoices.Setup(i => i.Expression).Returns(invoices.AsQueryable().Expression);
        _mockInvoices.Setup(i => i.ElementType).Returns(invoices.AsQueryable().ElementType);
    }
}
