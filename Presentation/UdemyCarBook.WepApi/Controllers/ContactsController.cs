using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Aplication.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Aplication.Features.CQRS.Handlers.ContactHandlers;
using UdemyCarBook.Aplication.Features.CQRS.Queries.ContactQueries;

namespace UdemyCarBook.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
            private readonly CreateContactCommandHandler _createCommandHandler;
            private readonly UpdateContactCommandHandler _updateContactCommandHandler;
            private readonly RemoveContactCommandHandler _removeContactCommandHandler;
            private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
            private readonly GetContactQueryHandler _getContactQueryHandler;

            public ContactsController(CreateContactCommandHandler createCommandHandler, UpdateContactCommandHandler updateContactCommandHandler, RemoveContactCommandHandler removeContactCommandHandler, GetContactByIdQueryHandler getContactByIdQueryHandler, GetContactQueryHandler getContactQueryHandler)
            {
                _createCommandHandler = createCommandHandler;
                _updateContactCommandHandler = updateContactCommandHandler;
                _removeContactCommandHandler = removeContactCommandHandler;
                _getContactByIdQueryHandler = getContactByIdQueryHandler;
                _getContactQueryHandler = getContactQueryHandler;
            }
            [HttpGet]
            public async Task<IActionResult> GetAllContact()
            {
                var values = await _getContactQueryHandler.Handle();
                return Ok(values);

            }
            [HttpPost]
            public async Task<IActionResult> CreateContact(CreateContactCommand ContactCommand)
            {
                await _createCommandHandler.Handle(ContactCommand);
                return Ok("İletişim eklendi");
            }
            [HttpPut]
            public async Task<IActionResult> UpdateContact(UpdateContactCommand ContactCommand)
            {
                await _updateContactCommandHandler.Handle(ContactCommand);
                return Ok("İletişim Güncellendi");
            }
            [HttpDelete]
            public async Task<IActionResult> DeleteContact(int id)
            {
                await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
                return Ok("İletişim Silindi");

            }
            [HttpGet("{id}")]
            public async Task<IActionResult> GetByContact(int id)
            {
                var values = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
                return Ok(values);
            }
        }
}
