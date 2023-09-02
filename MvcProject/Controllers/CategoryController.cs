using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetCategoryList()
        {
            var categoryValues = categoryManager.GetAll();
            return View(categoryValues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();

        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            //categoryManager.CategoryAdd
            CategoryValidatior categoryValidatior = new CategoryValidatior();
            ValidationResult validationResult = categoryValidatior.Validate(category);
            if(validationResult.IsValid) { 
                categoryManager.CategoryAdd(category);
                return RedirectToAction("GetCategoryList");

            }
            else
            {
                foreach(var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
