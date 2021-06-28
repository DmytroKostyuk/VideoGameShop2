using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using BLL.DTO;

namespace BLL.Validators
{
    public class PublisherValidator : AbstractValidator<PublisherDTO>
    {
        public PublisherValidator()
        {
            RuleFor(x => x.Name).Length(4,50).NotEmpty().WithMessage("Имя не может быть пустым");
        }
    }
}
