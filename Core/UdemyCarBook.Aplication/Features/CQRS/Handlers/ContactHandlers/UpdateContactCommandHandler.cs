using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Aplication.Features.CQRS.Commands.CategoryCommands;
using UdemyCarBook.Aplication.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Aplication.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Aplication.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactCommand command)
        {
            var value = await _repository.GetByIdAsync(command.ContactID);
              value.ContactID = command.ContactID;
            value.Subject = command.Subject;
            value.Messsage = command.Messsage;
            value.SendDate = command.SendDate;
            value.Name = command.Name;
            value.EMail = command.EMail;
            await _repository.UpdateAsync(value);
        }
    }
}
