using Encinecarlos.PaymentManager.Application.Transaction.dto;
using Encinecarlos.PaymentManager.Domain.Entities;
using Encinecarlos.PaymentManager.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encinecarlos.PaymentManager.Application.Transaction.Query
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<GetCategoriesDto>>
    {
        private readonly IRepository<Category, Guid> _repository;

        public GetCategoriesHandler(IRepository<Category, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetCategoriesDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetAllAsync();

            if(request.Filters.Name is not null || request.Filters.Description is not null) 
            {
                var filteredCategories = categories.Where(x => 
                x.Name == request.Filters.Name 
                || x.Description == request.Filters.Description);

                return await Task.FromResult(MapResponse(filteredCategories));
            }

            return await Task.FromResult(MapResponse(categories));
        }

        private IEnumerable<GetCategoriesDto> MapResponse(IEnumerable<Category> categories)
        {
            var result = new List<GetCategoriesDto>();
            foreach (var category in categories)
            {
                result.Add(new GetCategoriesDto
                {
                    CategoryId = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                });
            }

            return result;
        }
    }
}
