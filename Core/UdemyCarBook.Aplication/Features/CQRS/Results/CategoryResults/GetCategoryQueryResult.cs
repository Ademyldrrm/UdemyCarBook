﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Aplication.Features.CQRS.Results.CategoryResults
{
    public class GetCategoryQueryResult
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
    }
}
