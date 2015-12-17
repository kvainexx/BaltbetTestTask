using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Data.Migrations.Configurations
{
    public static class Records
    {
        public static void Seed(DataContext.DataContext context)
        {
            if (!context.Records.Any() && !context.Directories.Any())
            {
                var dir1 = new Entities.Directory()
                {
                    Name = "Папка 1"
                };
                var dir2 = new Entities.Directory()
                {
                    Name = "Папка 2"
                };
                var dir3 = new Entities.Directory()
                {
                    Name = "Папка 3"
                };

                for (int i = 1; i <= 50; i++)
                {
                    context.Records.Add(new Entities.Record()
                    {
                        Name = String.Format("Запись {0}", i),
                        Description = String.Format("Описание {0}", i),
                        Value = String.Format("Значение {0}", i),
                        IsFavorite = (i % 10 == 0) ? true : false,
                        Directory = (i % 2 != 0) ? (i % 3 == 0) ? dir3 : dir2 : dir1
                    });
                }
                context.SaveChanges();
            }
        }
    }
}
