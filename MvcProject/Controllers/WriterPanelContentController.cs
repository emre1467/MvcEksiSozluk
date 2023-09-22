using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
	public class WriterPanelContentController : Controller
	{
		private readonly ContentManager contentManager=new ContentManager(new EFContentDal());

		public WriterPanelContentController()
		{
			contentManager = new ContentManager(new EFContentDal());
		}

		[Authorize]
		public IActionResult MyContent()
		{

			int writerId = HttpContext.Session.GetInt32("WriterId") ?? 0;
			var value = contentManager.getListByWriter(writerId);

			string writerMail = HttpContext.Session.GetString("WriterMail");
			ViewBag.WriterMail = writerMail;
			ViewBag.WriterId = writerId;
			return View(value);
		}
		[HttpGet]
		public IActionResult AddContent(int id)
		{
			ViewBag.headingId = id;
			return View();
		}
        [HttpPost]
        public IActionResult AddContent(Content content)
        {
            int writerId = HttpContext.Session.GetInt32("WriterId") ?? 0;
            content.ContentDate = DateTime.Parse( DateTime.Now.ToShortDateString());
			content.WriterId= writerId;
			content.Status = true;
			contentManager.ContentAdd(content);
            return RedirectToAction("MyContent");
        }
		public IActionResult ToDoList()
		{
			return	View();
		}
    }
}
