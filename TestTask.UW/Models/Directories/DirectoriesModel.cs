using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.UW.Models.Directories
{
    public class DirectoriesModel
    {
        public IEnumerable<Data.Entities.Directory> Directories { get; set; }
    }
}