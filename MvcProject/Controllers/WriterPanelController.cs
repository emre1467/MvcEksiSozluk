using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PagedList;
using PagedList.Mvc;


namespace MvcProject.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EFHeadingDal());
        CategoryManager categoryManager= new CategoryManager(new EFCategoryDal());
        WriterManager writerManager=new WriterManager(new EFWriterDal());
        WriterValidator validatior = new WriterValidator();
        [HttpGet]
        public IActionResult WriterProfile(int id)
        {
            int writerId = HttpContext.Session.GetInt32("WriterId") ?? 0;

            var writerValue = writerManager.GetById(writerId);
            ViewBag.w = writerId;
            return View(writerValue);
        }
        [HttpPost]
        public IActionResult WriterProfile(Writer writer)
        {
            FluentValidation.Results.ValidationResult result = validatior.Validate(writer);
            if (result.IsValid)
            {
                writerManager.WriterUpdate(writer);
                return RedirectToAction("AllHeading");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }





        [Authorize]
        public IActionResult MyHeading(int id)
        {
			int sessionId = HttpContext.Session.GetInt32("WriterId") ?? 0;

			var values = headingManager.GetByWriterList(sessionId);
            return View(values);
        }
        [HttpGet]
        public IActionResult NewHeading()
        {
            List<SelectListItem> valueCategory =
                (from x in categoryManager.GetAll()
                 select new SelectListItem
                 {
                     Text = x.CategoryName,
                     Value = x.CategoryId.ToString()
                 }).ToList();
            ViewBag.vlc = valueCategory;
            return View();
        }
        [HttpPost]
        public IActionResult NewHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            
            int sessionId = HttpContext.Session.GetInt32("WriterId") ?? 0;
            heading.WriterId = sessionId;
            heading.Status = true;
            headingManager.HeadingAdd(heading);
            return RedirectToAction("MyHeading");
        }
        [HttpPost]
        public IActionResult NewWriter(Writer writer)
        {
            FluentValidation.Results.ValidationResult result = validatior.Validate(writer);
            if (result.IsValid)
            {
                writerManager.WriterAdd(writer);
                return View();
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult NewWriter()
        {
            return View();
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

           

            var headingValues = headingManager.getById(id);
            return View(headingValues);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.getById(id);
            headingValue.Status = false;
            headingManager.HeadingRemove(headingValue);
            return RedirectToAction("MyHeading");
        }

        public IActionResult AllHeading(int p=1)
        {
            var h=headingManager.GetAll().Count();
            ViewBag.h = h;
            var headings = headingManager.GetAll().ToPagedList(p,4);
            return View(headings);
        }

    }
}
