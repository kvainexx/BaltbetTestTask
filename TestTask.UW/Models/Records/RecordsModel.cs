using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.UW.Models.Records
{
    public class RecordsModel
    {
        public IEnumerable<Data.Entities.Record> Records { get; set; }

        public Paging Paging { get; set; }
    }
}