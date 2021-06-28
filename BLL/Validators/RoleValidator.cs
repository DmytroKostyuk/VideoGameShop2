using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using BLL.DTO;

namespace BLL.Validators
{
    public class RoleValidator : AbstractValidator<RoleDTO>
    {
        public RoleValidator()
        {
            RuleFor(x => x.Name).Length(5,20).NotEmpty();
        }
    }
}
