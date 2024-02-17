using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using UdemyCarBook.Application.Services;
using UdemyCarBook.Application.Tools;
using UdemyCarBook.Persistence.Context;
using UdemyCarBook.WebApi.Extensions;
using UdemyCarBook.WebApi.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();

builder.Services.AddCors(opt =>
{
	opt.AddPolicy("CorsPolicy", builder =>
	{
		builder.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed((host) => true).AllowCredentials();
	});
});
builder.Services.AddSignalR();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
	opt.RequireHttpsMetadata = false;
	opt.TokenValidationParameters = new TokenValidationParameters
	{
		ValidAudience = JwtTokenDefaults.ValidAudiance,
		ValidIssuer = JwtTokenDefaults.ValidIssuer,
		ClockSkew = TimeSpan.Zero, //tokenin baþlangýç süresini sýfýrlama
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
		ValidateLifetime = true, // token ayakta kalma zamaný
		ValidateIssuerSigningKey = true
	};
});

// Add services to the container.
builder.Services.AddScoped<CarBookContext>();
builder.Services.AddCustomServices();

builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddControllers().AddFluentValidation(x =>
{
	x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHub<CarHub>("/carhub");

app.Run();
