using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Title).NotEmpty().WithName("Başlık");
            RuleFor(x => x.Description).NotEmpty().WithName("Açıklama");
            RuleFor(x => x.BrandId)
                .GreaterThan(0)
                .WithName("Marka");
            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithName("Fiyat");

            RuleFor(x => x.CategoryIDs)
                .NotEmpty()
                .Must(cat => cat.Any())
                .WithName("Kategoriler");
        }
    }
}
