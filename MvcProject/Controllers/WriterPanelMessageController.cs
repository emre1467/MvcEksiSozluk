using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        WriterManager writerManager = new WriterManager(new EFWriterDal());
        public IActionResult Inbox()
        {
            int sessionId = HttpContext.Session.GetInt32("WriterId") ?? 0;
            var yazar = writerManager.GetById(sessionId);
            
            var messagelist = messageManager.GetListInbox(yazar.WriterMail);

            return View(messagelist);
        }
        public IActionResult Sendbox()
        {
            int sessionId = HttpContext.Session.GetInt32("WriterId") ?? 0;
            var yazar = writerManager.GetById(sessionId);

            var messageList = messageManager.GetListSendbox(yazar.WriterMail);
            return View(messageList);
        }
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
        public IActionResult GetInboxDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }
        public IActionResult GetSendboxDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }
        [HttpGet]
        public IActionResult NewMessage()
        {

            return View();
        }
        [HttpPost]
        public IActionResult NewMessage(Message message)
        {
            ValidationResult result = messageValidator.Validate(message);
            if (result.IsValid)
            {
                int sessionId = HttpContext.Session.GetInt32("WriterId") ?? 0;
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                var yazar = writerManager.GetById(sessionId);
                message.SenderMail = yazar.WriterMail;
                messageManager.MessageAdd(message);
                return RedirectToAction("Sendbox");
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

    }
}
