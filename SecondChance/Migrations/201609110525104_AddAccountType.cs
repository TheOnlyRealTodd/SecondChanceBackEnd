namespace SecondChance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AccountType", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AccountType");
        }
    }
}
