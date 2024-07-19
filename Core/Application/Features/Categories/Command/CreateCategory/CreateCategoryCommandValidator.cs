using Application.Features.Products.Command.CreateProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommandRequest>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithName("Kategori Adı");
            RuleFor(x => x.Priorty).NotEmpty().GreaterThan(0).WithName("Öncelik");
            
        }
    }
}
