namespace TestTask.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Directories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id, unique: true);
            
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        Description = c.String(maxLength: 50),
                        Value = c.String(maxLength: 50),
                        IsFavorite = c.Boolean(nullable: false),
                        Directory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Directories", t => t.Directory_Id)
                .Index(t => t.Id, unique: true)
                .Index(t => t.Directory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Records", "Directory_Id", "dbo.Directories");
            DropIndex("dbo.Records", new[] { "Directory_Id" });
            DropIndex("dbo.Records", new[] { "Id" });
            DropIndex("dbo.Directories", new[] { "Id" });
            DropTable("dbo.Records");
            DropTable("dbo.Directories");
        }
    }
}
