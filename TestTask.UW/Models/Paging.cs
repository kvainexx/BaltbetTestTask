using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.UW.Models
{
    public class Paging
    {
        public int Current { get; set; }
        public int PerPage { get; set; }
        public Total Total { get; set; }
    }

    public class Total
    {
        public int Items { get; set; }
        public int Pages { get; set; }
    }
}