namespace SecondChance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetOneToManyEmployersToJobs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Employer_EmployerId", c => c.Int());
            CreateIndex("dbo.Jobs", "Employer_EmployerId");
            AddForeignKey("dbo.Jobs", "Employer_EmployerId", "dbo.Employers", "EmployerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "Employer_EmployerId", "dbo.Employers");
            DropIndex("dbo.Jobs", new[] { "Employer_EmployerId" });
            DropColumn("dbo.Jobs", "Employer_EmployerId");
        }
    }
}
