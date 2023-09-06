using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;

namespace MvcProject.Controllers
{
    public class WriterController : Controller
    {

        WriterManager writerManager = new WriterManager(new EFWriterDal());
        WriterValidator validatior = new WriterValidator();

        public IActionResult Index()
        {
            var WriterValues = writerManager.GetAll();
            return View(WriterValues);
        }
        [HttpGet]
        public IActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddWriter(Writer writer)
        {
            FluentValidation.Results.ValidationResult result = validatior.Validate(writer);
            if(result.IsValid)
            {
                writerManager.WriterAdd(writer);
                return RedirectToAction("Index");
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
        public IActionResult EditWriter(int id)
        {
            var writerValue = writerManager.GetById(id);
            return View(writerValue);
        }
        [HttpPost]
        public IActionResult EditWriter(Writer writer)
        {
            FluentValidation.Results.ValidationResult result = validatior.Validate(writer);
            if (result.IsValid)
            {
                writerManager.WriterUpdate(writer);
                return RedirectToAction("Index");
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
