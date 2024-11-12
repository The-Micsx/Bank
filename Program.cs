using Bank.Connection;
using Bank.Interfaces;
using Bank.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BankSberContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PSQL"));
});

builder.Services.AddScoped<ICardTypeRepository, CardTypeRepository>();
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<IExchangeRateRepository, ExchangeRateRepository>();
builder.Services.AddScoped<IHomeAdreRepository, HomeAdreRepository>();
builder.Services.AddScoped<ITransactionHistoryRepository, TransactionHistoryRepository>();
builder.Services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
