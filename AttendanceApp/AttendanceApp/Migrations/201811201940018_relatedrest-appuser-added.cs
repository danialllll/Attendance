namespace AttendanceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relatedrestappuseradded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.rests", "person_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "email", c => c.String());
            CreateIndex("dbo.rests", "person_Id");
            AddForeignKey("dbo.rests", "person_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.rests", "person_Id", "dbo.AspNetUsers");
            DropIndex("dbo.rests", new[] { "person_Id" });
            AlterColumn("dbo.AspNetUsers", "email", c => c.String(maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String());
            DropColumn("dbo.rests", "person_Id");
        }
    }
}
