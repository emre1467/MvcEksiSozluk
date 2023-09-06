using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("yazar adı boş olamaz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında boş olamaz");
            //RuleFor(x => x.WriterAbout).Must(x=>!string.IsNullOrEmpty(x)&&x.Contains("a")).WithMessage("a harfi içermeli");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("3 karakterden az olamaz");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("50 karakterden fazla olamaz");

        }

    }
}
