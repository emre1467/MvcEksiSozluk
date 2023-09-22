using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization; // [AllowAnonymous] için gereken using direktifi
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EFHeadingDal());
        ContentManager contentManager = new ContentManager(new EFContentDal());

        [AllowAnonymous] // Bu aksiyona kimlik doğrulamasız erişim izni verilir
        public IActionResult Headings(int id = 1)
        {
            var headingList = headingManager.GetAll();
            ViewBag.Id = id;
            return View(headingList);
        }

        [AllowAnonymous] // Bu aksiyona kimlik doğrulamasız erişim izni verilir
        public IActionResult Index1()
        {
            var contents = contentManager.GetAll();
            return View(contents);
        }

        public PartialViewResult ContentList()
        {
            var contentList = contentManager.GetAll();
            return PartialView(contentList);
        }
    }
}
