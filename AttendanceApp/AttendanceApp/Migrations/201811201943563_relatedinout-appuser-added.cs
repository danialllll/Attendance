namespace AttendanceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relatedinoutappuseradded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUserinouts",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        inout_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.inout_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.inouts", t => t.inout_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.inout_Id);
            
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "email", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserinouts", "inout_Id", "dbo.inouts");
            DropForeignKey("dbo.ApplicationUserinouts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserinouts", new[] { "inout_Id" });
            DropIndex("dbo.ApplicationUserinouts", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.AspNetUsers", "email", c => c.String(maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String());
            DropTable("dbo.ApplicationUserinouts");
        }
    }
}
