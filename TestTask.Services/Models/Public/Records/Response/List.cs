using System.Collections.Generic;
using TestTask.Data.Entities;

namespace TestTask.Services.Models.Public.Records.Response
{
    public class List
    {
        public List<Record> Records { get; set; }

        public Paging Paging { get; set; }
    }
}
