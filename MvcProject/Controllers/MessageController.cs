using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace MvcProject.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        public IActionResult Inbox()
        {
            var messagelist = messageManager.GetListInbox("admin@gmail.com");

            return View(messagelist);
        }
        public IActionResult Sendbox()
        {
            var messageList=messageManager.GetListSendbox("admin@gmail.com");
            return View(messageList);
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
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
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


        public IActionResult GetInboxDetails(int id)
        {
            var values=messageManager.GetById(id);
            return View(values);
        }
        public IActionResult GetSendboxDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }

    }
}
