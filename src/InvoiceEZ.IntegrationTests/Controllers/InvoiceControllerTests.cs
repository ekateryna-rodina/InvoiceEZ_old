using FluentAssertions;
using InvoiceEZ.API;
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
        var invoiceId = 1;

        // Act
        var response = await _httpClient.GetAsync(APIRoutes.Invoice.TotalByInvoiceId.Replace("{id}", invoiceId.ToString()));

        // Assert
        var responseContent = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<decimal>(responseContent);
        response.EnsureSuccessStatusCode();
        result.Should().Be(15.99m);
    }
}
