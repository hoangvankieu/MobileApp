using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MobileApp.Models;
using MobileApp.Repositories;
using MobileApp.Services;
using Newtonsoft.Json;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var conString = builder.Configuration.GetConnectionString("ConnectString");

builder.Services.AddDbContext<MobileAppDBcontext>(options => options.UseSqlServer(conString));
//Cấu hình xác thực jwt
var scurity_key = builder.Configuration["Jwt:Key"];
builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
   .AddJwtBearer(options =>
   {
	   options.RequireHttpsMetadata = false; // Chỉ yêu cầu HTTPS trong môi trường sản xuất
	   options.SaveToken = true;
	   options.TokenValidationParameters = new TokenValidationParameters
	   {
		   ValidateIssuerSigningKey = true,
		   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(scurity_key ?? "")),
		   ValidateIssuer = false,
		   ValidateAudience = false
	   };
   });


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IStaffRepository, StaffRepository>();
builder.Services.AddScoped<IStaffSevice, StaffSevice>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Staff}/{action=Register}/{id?}");

app.Run();
