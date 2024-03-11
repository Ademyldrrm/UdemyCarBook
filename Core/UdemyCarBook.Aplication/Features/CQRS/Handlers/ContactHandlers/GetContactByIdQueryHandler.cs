using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Aplication.Features.CQRS.Queries.ContactQueries;
using UdemyCarBook.Aplication.Features.CQRS.Results.ContactResults;
using UdemyCarBook.Aplication.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Aplication.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<GetContactGetByIdQueryResult> Handle(GetContactByIdQuery getContact)
        {
            var values = await _repository.GetByIdAsync(getContact.Id);
            return new GetContactGetByIdQueryResult
            {
                ContactID = values.ContactID,
                Name = values.Name,
                Subject = values.Subject,   
                Messsage = values.Messsage, 
                SendDate = values.SendDate, 
                EMail = values.EMail    
            };
        }
    }
}
