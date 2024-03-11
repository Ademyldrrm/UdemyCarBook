using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Aplication.Features.CQRS.Commands.CategoryCommands
{
    public class CreateCategoryCommand
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
    }
}
