using SOLIDPrinciples.Factories;
using SOLIDPrinciples.Interfaces;
using SOLIDPrinciples.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
                                     
                                  // to show enum parameters in swagger dropdown
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IDiscountStrategy>(new NoDiscount());
builder.Services.AddSingleton<DiscountFactory>();
builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton<IReadableProductService>(sp => sp.GetRequiredService<ProductService>());
builder.Services.AddSingleton<IWritableProductService>(sp => sp.GetRequiredService<ProductService>());


var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.UseAuthorization();
app.MapControllers();
app.Run();
