using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MvcProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // ...

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
          .AddCookie(options =>
          {
              options.LoginPath = "/Login/Index"; // Kimlik doğrulama işlemi gerektiren bir sayfa yoksa yönlendirilecek sayfa
          });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ...


            app.UseAuthentication(); // Kimlik doğrulama kullanılacaksa eklenmelidir
            app.UseAuthorization();


            // ...
        }
    }
}
