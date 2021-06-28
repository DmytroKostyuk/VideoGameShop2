using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using BLL.DTO;

namespace BLL.Validators
{
    public class GameValidator : AbstractValidator<GameDTO>
    {
        public GameValidator()
        {
            RuleFor(x => x.Name).Length(4,50).NotEmpty().WithMessage("Имя не может быть пустым");
            RuleFor(x => x.Cost).LessThanOrEqualTo(2500).WithMessage("Максимальная цена игры - 2500");
        }
    }
}
