﻿using Moq;
using InvoiceEZ.Domain.Models;
using InvoiceEZ.Infrastructure.Repositories;
using FluentAssertions;
using InvoiceEZ.UnitTests.Utils;

namespace InvoiceEZ.UnitTests;

public class InvoiceRepositoryTests
{
    private Mock<IQueryable<Invoice>> _mockInvoices = new Mock<IQueryable<Invoice>>();

    [SetUp]
    public void Setup()
    {
       
    }

    // Using TestCaseSource is a workaround to allow decimal as a parameter for TestCaseAttribute
    [Test, TestCaseSource(typeof(TestCaseUtils), nameof(TestCaseUtils.TotalCaseParams))]
    [TestCase(Int32.MinValue)]
    [TestCase(Int32.MaxValue)]
    [TestCase(5)]
    [TestCase(-1)]
    public void GetTotal_InvoicesExist_CorrectValueShouldBeReturned(int input, decimal? output = null)
    {
        var invoices = TestCaseUtils.SeedInvoices;
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

    private void SeedInvoiceRepository(IEnumerable<Invoice> invoices) {
        _mockInvoices.Setup(i => i.GetEnumerator()).Returns(invoices.GetEnumerator());
        _mockInvoices.Setup(i => i.Provider).Returns(invoices.AsQueryable().Provider);
        _mockInvoices.Setup(i => i.Expression).Returns(invoices.AsQueryable().Expression);
        _mockInvoices.Setup(i => i.ElementType).Returns(invoices.AsQueryable().ElementType);
    }
}