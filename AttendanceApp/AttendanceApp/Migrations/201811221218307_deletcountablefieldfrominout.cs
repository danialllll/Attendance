namespace AttendanceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletcountablefieldfrominout : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "email", c => c.String());
            DropColumn("dbo.inouts", "workInThisDay");
            DropColumn("dbo.inouts", "delayInThisDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.inouts", "delayInThisDay", c => c.Int(nullable: false));
            AddColumn("dbo.inouts", "workInThisDay", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "email", c => c.String(maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String());
        }
    }
}
