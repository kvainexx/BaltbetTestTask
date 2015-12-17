using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.UW.App_Start
{
    public class MapperConfig
    {
        public static void Initialize()
        {
            Models.Mapping.Initialize();
        }
    }
}