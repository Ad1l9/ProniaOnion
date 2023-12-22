using FluentValidation;
using ProniaOnion.Application.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.Validators
{
    public class ProductCreateDtoValidator:AbstractValidator<CreateProductDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is important")
                .MaximumLength(100).WithMessage("Name may contain maximum 100 character")
                .MinimumLength(2).WithMessage("Name may contain at least 2 character");

            RuleFor(x => x.SKU).NotEmpty().MaximumLength(10).WithMessage("Name may contain maximum 10 character");

            RuleFor(x => x.Price).NotEmpty().Must(x=>x>10 && x<999999.99m);

            RuleFor(x => x.Description).MaximumLength(1000);
        }

    }
}
