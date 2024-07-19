using Application.Automapper;
using Application.DTOs;
using Application.UnitOfWorks;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(include : x=>x.Include(c=>c.Brand)); // tüm hepsi geldi.Maplemek lazım

            var brand = mapper.Map<BrandDTO, Brand>(new Brand());

            ////Eski usul maplemek için burası
            //List<GetAllProductsQueryResponse> response = new();

            //foreach (var item in products)
            //{
            //    response.Add(new GetAllProductsQueryResponse
            //    {
            //        Title=item.Title,
            //        Description=item.Description,
            //        //Discount=item.Discount,
            //        Price= item.Price

            //    });                
            //}
            //IMAPPEr ile map işlemi
            var map = mapper.Map<GetAllProductsQueryResponse
, Product>(products);
            //map işlemi sonrası fiyat işlemleri varsa burada yapılablir.
            return map;
        }
    }
}
