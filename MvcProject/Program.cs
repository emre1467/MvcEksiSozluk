using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// ConfigureServices metodu burada çaðrýlýr
		ConfigureServices(builder.Services);

		var app = builder.Build();

		// Configure metodu burada çaðrýlýr
		Configure(app, builder.Environment);

		app.Run();
	}

	public static void ConfigureServices(IServiceCollection services)
	{
		services.AddControllersWithViews();

		services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
			.AddCookie(options =>
			{
				options.LoginPath = "/Login/WriterLogin"; // Kimlik doðrulama baþarýsýzsa yönlendirilecek sayfa
				options.AccessDeniedPath = "/Home/AccessDenied"; // Eriþim reddedildiðinde yönlendirilecek sayfa
			});

		services.AddAuthorization(options =>
		{
			options.AddPolicy("RequireAuthenticatedUser", policy =>
			{
				policy.RequireAuthenticatedUser(); // Kimlik doðrulama zorunlu
			});
		});


		services.AddMvc(options =>
		{
			var policy = new AuthorizationPolicyBuilder()
				.RequireAuthenticatedUser()
				.Build();
			options.Filters.Add(new AuthorizeFilter(policy));
		});

		services.AddSession();
	}

	public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}
		else
		{
			app.UseExceptionHandler("/Home/Error");
			app.UseHsts();
		}

		app.UseHttpsRedirection();
		app.UseStaticFiles();

		app.UseRouting();

		app.UseAuthentication(); // Kimlik doðrulama kullan
		app.UseAuthorization();
		app.UseSession();
		app.UseEndpoints(endpoints =>
		{
			endpoints.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Homepage}/{id?}")
				.RequireAuthorization("RequireAuthenticatedUser"); // Kimlik doðrulama zorunlu olan eylem
		});
	}
}
