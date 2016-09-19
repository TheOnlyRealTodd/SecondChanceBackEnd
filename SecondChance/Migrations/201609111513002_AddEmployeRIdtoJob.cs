namespace SecondChance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeRIdtoJob : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "Employer_EmployerId", "dbo.Employers");
            DropIndex("dbo.Jobs", new[] { "Employer_EmployerId" });
            RenameColumn(table: "dbo.Jobs", name: "Employer_EmployerId", newName: "EmployerId");
            AlterColumn("dbo.Jobs", "EmployerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Jobs", "EmployerId");
            AddForeignKey("dbo.Jobs", "EmployerId", "dbo.Employers", "EmployerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "EmployerId", "dbo.Employers");
            DropIndex("dbo.Jobs", new[] { "EmployerId" });
            AlterColumn("dbo.Jobs", "EmployerId", c => c.Int());
            RenameColumn(table: "dbo.Jobs", name: "EmployerId", newName: "Employer_EmployerId");
            CreateIndex("dbo.Jobs", "Employer_EmployerId");
            AddForeignKey("dbo.Jobs", "Employer_EmployerId", "dbo.Employers", "EmployerId");
        }
    }
}
