using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using BLL.DTO;

namespace BLL.Validators
{
    public class GenreValidator : AbstractValidator<GenreDTO> 
    {
        public GenreValidator()
        {
            RuleFor(x => x.Name).Length(3,50).NotEmpty().WithMessage("Имя не может быть пустым");
        }
    }
}
