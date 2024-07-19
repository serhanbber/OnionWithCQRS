using Application.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Command.DeleteBrand
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteBrandCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var brand = await unitOfWork.GetReadRepository<Brand>().GetAsync(x=>x.Id==request.Id && !x.IsDeleted);
            brand.IsDeleted= true;
            await unitOfWork.GetWriteRepository<Brand>().UpdateAsync(brand);
            await unitOfWork.SaveAsync();
            return Unit.Value;

        }
    }
}
