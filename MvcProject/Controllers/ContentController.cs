using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EFContentDal());
            
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ContentByHeading(int id)
        {
            var contentValues=contentManager.getListByHeadingID(id);
            return View(contentValues);
        }

    }
}
