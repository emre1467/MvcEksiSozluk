using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
        [Authorize]
        public IActionResult Index()
        {
            var categoryValues=categoryManager.GetAll();
            return View(categoryValues);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            CategoryValidatior validations = new CategoryValidatior();
            ValidationResult validationResult = validations.Validate(category);
            if(validationResult.IsValid)
            {
                categoryManager.CategoryAdd(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            
            return View();
        }
        public IActionResult DeleteCategory(int id)
        {
            var categoryValue = categoryManager.getById(id);
            categoryManager.CategoryDelete(categoryValue);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryValue = categoryManager.getById(id);
            return View(categoryValue);
        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            categoryManager.CategoryUpdate(category);
            return RedirectToAction("Index");
        }
    }
}
