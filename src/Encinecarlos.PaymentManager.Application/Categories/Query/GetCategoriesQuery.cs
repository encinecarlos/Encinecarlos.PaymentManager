using Encinecarlos.PaymentManager.Application.Categories.dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encinecarlos.PaymentManager.Application.Categories.Query
{
    public class GetCategoriesQuery : IRequest<IEnumerable<GetCategoriesDto>>
    {
        public GetCategoriesRequest? Filters { get; set; }
    }
}
