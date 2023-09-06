using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EFContactDal());
        ContactValidator validator= new ContactValidator();


        public IActionResult Index()
        {
            var contactvalues = contactManager.GetAll();
            return View(contactvalues);
        }


        public IActionResult Details(int id)
        {
            var contactcvalues= contactManager.getById(id);
            return View(contactcvalues);
        }
        
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}
