namespace ASP.NET_Developer_Challenge_test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Interrests",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        IsSelected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Services");
            DropTable("dbo.Interrests");
        }
    }
}
