using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Aplication.Features.CQRS.Results.ContactResults
{
    public class GetContactGetByIdQueryResult
    {
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Subject { get; set; }
        public string Messsage { get; set; }
        public DateTime SendDate { get; set; }
    }
}
