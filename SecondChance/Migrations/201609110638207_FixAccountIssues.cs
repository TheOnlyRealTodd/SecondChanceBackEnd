namespace SecondChance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixAccountIssues : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsEmployer", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "AccountType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "AccountType", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "IsEmployer");
        }
    }
}
