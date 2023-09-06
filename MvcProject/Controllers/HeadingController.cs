using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcProject.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EFHeadingDal());
        CategoryManager categoryManager= new CategoryManager(new EFCategoryDal());
        WriterManager writerManager= new WriterManager(new EFWriterDal());
        public IActionResult Index()
        {
            var headingValues = headingManager.GetAll();
            return View(headingValues);
        }
        [HttpGet]
        public IActionResult AddHeading()
        {
            List<SelectListItem> valueCategory =
                (from x in categoryManager.GetAll() 
                 select new SelectListItem 
                 { Text = x.CategoryName, 
                     Value = x.CategoryId.ToString() }).ToList();
            ViewBag.vlc=valueCategory;


            List<SelectListItem> valueWriter =
                (from x in writerManager.GetAll()
                 select new SelectListItem
                 {
                     Text = x.WriterName + " "+x.WriterSurName,
                     Value = x.WriterId.ToString()
                 }).ToList();
            ViewBag.vlw = valueWriter;
            return View();
        }
        [HttpPost]
        public IActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.HeadingAdd(heading);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {

            List<SelectListItem> valueCategory =
                (from x in categoryManager.GetAll()
                 select new SelectListItem
                 {
                     Text = x.CategoryName,
                     Value = x.CategoryId.ToString()
                 }).ToList();
            ViewBag.vlc = valueCategory;

            List<SelectListItem> valueWriter =
               (from x in writerManager.GetAll()
                select new SelectListItem
                {
                    Text = x.WriterName + " " + x.WriterSurName,
                    Value = x.WriterId.ToString()
                }).ToList();
            ViewBag.vlw = valueWriter;

            var headingValues = headingManager.getById(id);
            return View(headingValues);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            headingManager.HeadingUpdate(heading); 
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue=headingManager.getById(id);
            headingValue.Status = false;
            headingManager.HeadingRemove(headingValue);
            return RedirectToAction("index");
        }

    }
}
