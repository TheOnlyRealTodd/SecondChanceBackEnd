namespace SecondChance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFelonToUserAndSetUpControllers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        AboutMe = c.String(nullable: false),
                        FeloniesCommitted = c.String(nullable: false),
                        Skill1 = c.String(),
                        Skill2 = c.String(),
                        Skill3 = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            DropTable("dbo.Felons");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Felons",
                c => new
                    {
                        FelonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        AboutMe = c.String(nullable: false),
                        FeloniesCommitted = c.String(nullable: false),
                        Skill1 = c.String(),
                        Skill2 = c.String(),
                        Skill3 = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FelonId);
            
            DropTable("dbo.Users");
        }
    }
}
