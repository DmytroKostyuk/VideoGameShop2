using BLL.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;


namespace BLL.Validators
{
    public class DeveloperValidator : AbstractValidator<DeveloperDTO>
    {
        public DeveloperValidator()
        {
            RuleFor(x => x.Name).Length(5,50).NotEmpty().WithMessage("Имя не может быть пустым");
        }
    }
}
