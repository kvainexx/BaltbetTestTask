using System.Data.Entity.Migrations;

namespace TestTask.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<DataContext.DataContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(DataContext.DataContext context)
        {
            Configurations.Records.Seed(context);
        }
    }
}
