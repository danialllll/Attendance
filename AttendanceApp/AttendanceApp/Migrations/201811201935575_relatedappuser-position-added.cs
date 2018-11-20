namespace AttendanceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relatedappuserpositionadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "position_Id", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "email", c => c.String());
            CreateIndex("dbo.AspNetUsers", "position_Id");
            AddForeignKey("dbo.AspNetUsers", "position_Id", "dbo.positions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "position_Id", "dbo.positions");
            DropIndex("dbo.AspNetUsers", new[] { "position_Id" });
            AlterColumn("dbo.AspNetUsers", "email", c => c.String(maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String());
            DropColumn("dbo.AspNetUsers", "position_Id");
        }
    }
}
