using Application.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Command.CreateBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommandRequest,Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateBrandCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            Brand brand = new(request.Name);
            await unitOfWork.GetWriteRepository<Brand>().AddAsync(brand);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
