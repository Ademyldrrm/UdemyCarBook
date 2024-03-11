using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Aplication.Features.CQRS.Queries.CategoryQueries;
using UdemyCarBook.Aplication.Features.CQRS.Results.CategoryResults;
using UdemyCarBook.Aplication.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Aplication.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryByIdQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task<GetCategoryByIdQueryResults> Handle(GetCategoryByIdQuery getCategory)
        {
            var values = await _repository.GetByIdAsync(getCategory.Id);
            return new GetCategoryByIdQueryResults
            {
                CategoryID = values.CategoryID,
                Name = values.Name
            }; 
                
        }
    }
}
