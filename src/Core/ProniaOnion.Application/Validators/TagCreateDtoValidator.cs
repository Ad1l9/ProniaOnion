using FluentValidation;
using ProniaOnion.Application.Dtos.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.Validators
{
    internal class TagCreateDtoValidator:AbstractValidator<CreateTagDto>
    {
        public TagCreateDtoValidator()
        {
            RuleFor(t => t.name).NotEmpty().MaximumLength(20);
        }
    }
}
