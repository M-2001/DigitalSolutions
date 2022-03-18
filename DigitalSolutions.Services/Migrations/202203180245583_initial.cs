namespace DigitalSolutions.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerEntries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 200),
                        company = c.String(nullable: false, maxLength: 20),
                        email = c.String(nullable: false, maxLength: 20),
                        phoneNumber = c.String(nullable: false, maxLength: 20),
                        message = c.String(nullable: false, maxLength: 20),
                        enabled = c.Boolean(nullable: false),
                        createDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerEntries");
        }
    }
}
