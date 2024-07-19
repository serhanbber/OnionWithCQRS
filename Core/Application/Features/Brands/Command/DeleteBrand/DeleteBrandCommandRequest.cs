﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Command.DeleteBrand
{
    public class DeleteBrandCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
