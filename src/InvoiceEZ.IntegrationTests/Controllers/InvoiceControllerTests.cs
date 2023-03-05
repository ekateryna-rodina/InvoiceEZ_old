using System.Net;
using FluentAssertions;
using InvoiceEZ.API;
using InvoiceEZ.Application.Helpers;
using InvoiceEZ.Shared.MockData;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;

namespace InvoiceEZ.Controllers;

public class InvoiceControllerTests
{
    private readonly HttpClient _httpClient;

    public InvoiceControllerTests() {
        var appFactory = new WebApplicationFactory<Program>();
        _httpClient = appFactory.CreateClient();
    }

    [Test]
    public async Task GetTotalByInvoiceId_InvoiceExist_ShouldReturnCorrectTotal()
    {
        // Arrange
        var invoice = Invoices.Total.InvoiceTestCases[0];
        var invoiceId = invoice.Id;
        var total = Invoices.Total.ResultTestCases[invoiceId];

        // Act
        var response = await _httpClient.GetAsync(APIRoutes.Invoice.TotalByInvoiceId.Replace("{id}", invoiceId.ToString()));

        // Assert
        var responseContent = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();
        var result = JsonConvert.DeserializeObject<decimal?>(responseContent);
        result!.Should().Be(total);
    }
    [Test]
    public async Task GetTotalByInvoiceId_NoInvoice_ShouldReturnNull()
    {
        // Arrange
        var invoiceId = 33;
     
        // Act
        var response = await _httpClient.GetAsync(APIRoutes.Invoice.TotalByInvoiceId.Replace("{id}", invoiceId.ToString()));

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        var responseContent = await response.Content.ReadAsStringAsync();
        responseContent.Should().Be("The invoice with the given id was not found.");
    }
}
