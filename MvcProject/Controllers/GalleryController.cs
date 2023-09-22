using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager ImageFileManager = new ImageFileManager(new EFImageDal());
        public IActionResult Index()
        {
            var values = ImageFileManager.GetAll();
            return View(values);
        }
    }
}
