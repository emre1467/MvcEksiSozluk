using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MvcProject.Controllers
{
	[AllowAnonymous]
    public class LoginController : Controller
    {
        AdminManager adminManager = new AdminManager(new EFAdminDal());
        WriterManager writerManager = new WriterManager(new EFWriterDal());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(Admin admin)
        {
            var adminUser=adminManager.GetByUserNameandPassword(admin.AdminUserName,admin.AdminPassword);
			if (adminUser != null)
			{
				// Kullanıcıyı kimlik doğrulama işlemi başarılıysa oturum açın
				var claims = new List<Claim>
	{
		new Claim(ClaimTypes.Name, adminUser.AdminUserName),
        // Diğer gerekli iddia türlerini buraya ekleyin.
    };

				var claimsIdentity = new ClaimsIdentity(
					claims, CookieAuthenticationDefaults.AuthenticationScheme);

				var authProperties = new AuthenticationProperties
				{
					// Oturum açma sırasında kullanılacak ayarlar (isteğe bağlı)
				};

				await HttpContext.SignInAsync(
					CookieAuthenticationDefaults.AuthenticationScheme,
					new ClaimsPrincipal(claimsIdentity),
					authProperties);

				return RedirectToAction("Index", "AdminCategory");
			}
            return View();
		}
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> WriterLogin(Writer writer)
        {
            var writerUser = writerManager.GetByUserNameandPassword(writer.WriterMail,writer.WriterPassword);
			if (writerUser != null)
			{
				// Kullanıcıyı kimlik doğrulama işlemi başarılıysa oturum açın
				var claims = new List<Claim>
	{
		new Claim(ClaimTypes.Name, writerUser.WriterMail),
        // Diğer gerekli iddia türlerini buraya ekleyin.
    };

				var claimsIdentity = new ClaimsIdentity(
					claims, CookieAuthenticationDefaults.AuthenticationScheme);

			 	var authProperties = new AuthenticationProperties
				{
					// Oturum açma sırasında kullanılacak ayarlar (isteğe bağlı)
				};

				await HttpContext.SignInAsync(
					CookieAuthenticationDefaults.AuthenticationScheme,
					new ClaimsPrincipal(claimsIdentity),
					authProperties);

				HttpContext.Session.SetInt32("WriterId", writerUser.WriterId);


				return RedirectToAction("MyContent", "WriterPanelContent");
			}
			else
			{
				ViewBag.w = "Hatalı mail veya şifre";
			}
			return View();
        }

        public async Task<IActionResult> Logout()
        {
            // Kullanıcının oturumunu sonlandır
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Kullanıcıyı başka bir sayfaya yönlendirin (örneğin, ana sayfaya)
            return RedirectToAction("Headings", "Default");
        }

    }
}
