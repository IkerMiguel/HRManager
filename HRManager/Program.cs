using HRManager.Data;
using Microsoft.EntityFrameworkCore;

namespace HRManager
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorPages();

			builder.Services.AddDbContext<ManagerContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("ManagerDB"))
			);
			builder.Services.AddAuthentication().AddCookie("MyCookieAuth", option =>
			{
				option.Cookie.Name = "MyCookieAuth";
				option.LoginPath = "/Account/Login";
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapRazorPages();

			app.Run();
		}
	}
}
