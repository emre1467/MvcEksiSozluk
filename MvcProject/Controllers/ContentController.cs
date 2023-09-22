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
        public  IActionResult GetSearchContent(string p="")
        {
            var values = contentManager.GetListSearch(p);
            return View(values);
        }
        public IActionResult ContentByHeading(int id)
        {
            var contentValues=contentManager.getListByHeadingID(id);
            return View(contentValues);
        }

    }
}
