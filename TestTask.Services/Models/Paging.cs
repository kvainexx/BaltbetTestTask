﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Services.Models
{
    public class Paging
    {
        public int Page { get; set; }

        public int Rows { get; set; }

        public int TotalItems { get; set; }
    }
}
