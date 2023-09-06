using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("mail adı boş olamaz");
            RuleFor(x => x.Message).NotEmpty().WithMessage("mesaj boş olamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("konu boş olamaz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("ad boş olamaz");
            //RuleFor(x => x.WriterAbout).Must(x=>!string.IsNullOrEmpty(x)&&x.Contains("a")).WithMessage("a harfi içermeli");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("3 karakterden az olamaz");

        }

    }
}
