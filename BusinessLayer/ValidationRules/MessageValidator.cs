using FluentValidation;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("mail adı boş olamaz").EmailAddress().WithMessage("bir email adresi olmalı"); 
            RuleFor(x => x.Subject).NotEmpty().WithMessage("konu adı boş olamaz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("mesaj boş olamaz");

        }
    }
}
