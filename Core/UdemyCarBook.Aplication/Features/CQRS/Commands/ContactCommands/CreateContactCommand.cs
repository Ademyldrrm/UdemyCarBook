using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Aplication.Features.CQRS.Commands.ContactCommands
{
    public class CreateContactCommand
    {
      
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Subject { get; set; }
        public string Messsage { get; set; }
        public DateTime SendDate { get; set; }
    }
}
