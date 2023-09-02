using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidatior:AbstractValidator<Category>
    {
        public CategoryValidatior()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş olamaz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama boş olamaz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("3 karakterden az olamaz");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("20 karakterden fazla olamaz");
        }
    }
}
