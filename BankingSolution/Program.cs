using BankingSolution.DataModels;
using BankingSolution.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("BankingSolution") ?? throw new InvalidOperationException("Connection string 'ProductContext' not found.")));
builder.Services.AddScoped<AccountServices>();
builder.Services.AddScoped<CustomerServices>();
builder.Services.AddScoped<TransactionServices>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
var app = builder.Build();


// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
