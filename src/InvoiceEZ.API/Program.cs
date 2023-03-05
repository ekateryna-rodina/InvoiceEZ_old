using InvoiceEZ.Application.Contracts;
using InvoiceEZ.Domain.Repositories;
using InvoiceEZ.Infrastructure.Repositories;
using InvoiceEZ.Shared.MockData;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>(provider =>
{
    var invoices = Invoices.Total.InvoiceTestCases;
    var queryableInvoices = invoices.AsQueryable();
    return new InvoiceRepository(queryableInvoices);
});
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

