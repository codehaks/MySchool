using FluentValidation;
using Portal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.Classes
{
    public class ClassValidator : AbstractValidator<Class>
    {
        public ClassValidator()
        {
            RuleFor(c => c.Location).NotEmpty().WithMessage("Class location is not specified");
            RuleFor(c => c.Location).MaximumLength(50).WithMessage("Class location is too long");

            RuleFor(c => c.Teacher).NotEmpty().WithMessage("Class teacher is not specified");
            RuleFor(c => c.Teacher).MaximumLength(30).WithMessage("Class location is too long");

            RuleFor(c => c.Name).NotEmpty().WithMessage("Class name is not specidied");
            RuleFor(c => c.Name).MaximumLength(20).WithMessage("Class location is too long");

        }
    }
}
