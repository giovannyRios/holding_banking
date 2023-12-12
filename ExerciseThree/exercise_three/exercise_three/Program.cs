using exercise_three.Models;
using exercise_three.Services.Implements;
using exercise_three.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configuration
builder.Services.Configure<resources>(builder.Configuration.GetSection("resources"));
builder.Services.AddScoped<IBase, Base>();
builder.Services.AddScoped<IProcessHttp, ProcessHttpResponse>();

//bussines services
builder.Services.AddScoped<IConvertTypeCurrencyService, ConvertTypeCurrencyService>();
builder.Services.AddScoped<IGetAndConvertAnyCurrencyService, GetAndConvertAnyCurrencyService>();
builder.Services.AddScoped<IHistoryLastAvailableYearService, HistoryLastAvailableYearService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapGet("/HistoryLastAvailableYearCurrency", async (HttpContext context, IHistoryLastAvailableYearService HistoryLastAvailableYearService) =>
{
	var result = await HistoryLastAvailableYearService.resultTransaction();
	await context.Response.WriteAsJsonAsync(result);
})
.WithName("HistoryLastAvailableYearCurrency")
.WithDescription("Extraer y presentar de manera legible la información del último año para cada uno de los siguientes pares de monedas: USDCOP, EURCOP, MXNCOP, COPUSD, COPMXN, COPEUR")
.WithOpenApi();


app.MapGet("/ConvertTypeCurrency", async (HttpContext context, IConvertTypeCurrencyService ConvertTypeCurrencyService) =>
{
	var result = await ConvertTypeCurrencyService.resultTransaction();
	await context.Response.WriteAsJsonAsync(result);
})
.WithName("ConvertTypeCurrency")
.WithDescription(" Convierta USD 25 en cada una de las siguientes monedas: EUR, MXN, COP para la fecha de la ejecución de la prueba y para el día 01/09/2023")
.WithOpenApi();

app.MapGet("/GetAndConvertAnyCurrency", async (HttpContext context, IGetAndConvertAnyCurrencyService GetAndConvertAnyCurrencyService) =>
{
	var result = await GetAndConvertAnyCurrencyService.resultTransaction();
	await context.Response.WriteAsJsonAsync(result);
})
.WithName("GetAndConvertAnyCurrency")
.WithDescription(" Consultar y actualizar el valor actual para cada uno de los siguientes pares de monedas USDCOP, EURCOP, MXNCOP, COPUSD, COPMXN, COPEUR únicamente si ha variado desde la última actualización")
.WithOpenApi();

app.Run();

