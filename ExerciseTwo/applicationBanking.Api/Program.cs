using applicationBanking.Infrastructure.IoC;
using ApplicationBanking.Filters;
using ApplicationBanking.services.Implements;
using ApplicationBanking.services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Add DbContext
IoCRegister.AddDbContext(builder.Services, builder.Configuration.GetSection("SchemaName").Value);

builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
).AddJwtBearer(
	options =>
	{
		options.RequireHttpsMetadata = false;
		options.SaveToken = true;
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = builder.Configuration["Jwt:Issuer"],
			ValidAudience = builder.Configuration["Jwt:Audience"],
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
		};

	});


//Configure JWT in Swagger
builder.Services.AddSwaggerGen(c =>
{

	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Description = "JWT de acceso",
		Name = "Authorization",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.Http,
		Scheme = "Bearer"
	});
	c.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
			},
			Array.Empty<string>()
		}
	});

});

//Inversion of Control project applicationBanking.Domain, applicationBanking.Infrastructure, Onion
IoCRegister.GetConfiguration(builder.Services);

//Add Mapper
var config = new MapperConfig();
builder.Services.AddSingleton(config.getMappper());

//Add JWT Service
builder.Services.AddSingleton<IJwtService, JwtService>();

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountMovementService, AccountMovementService>();


//Add Filters
builder.Services.AddTransient<ValidateJwtFilter>();


var app = builder.Build();

app.Use(async (context, next) =>
{
	context.Response.Headers.Add("x-frame-options", "DENY");
	context.Response.Headers.Remove("server");
	context.Response.Headers.Remove("x-powered-by");
	await next();

});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		// Habilita la autorización de Swagger
		c.OAuthClientId("swagger-client-id");
		c.OAuthClientSecret("swagger-client-secret");
		c.OAuthAppName("Swagger");
	});
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();