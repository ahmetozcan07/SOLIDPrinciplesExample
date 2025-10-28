using SOLIDPrinciples.Interfaces;
using SOLIDPrinciples.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IDiscountStrategy>(new PercentageDiscount(10));
builder.Services.AddSingleton<IReadableProductService, ProductService>();
builder.Services.AddSingleton<IWritableProductService, ProductService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
