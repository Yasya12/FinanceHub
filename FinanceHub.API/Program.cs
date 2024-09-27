using FinanceGub.Application;
using FinanceHub.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Додаємо сервіси до контейнера
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Налаштування конвеєра запитів
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();