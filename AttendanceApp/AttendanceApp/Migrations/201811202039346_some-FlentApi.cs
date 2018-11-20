namespace AttendanceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class someFlentApi : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.rests", "person_Id", "dbo.AspNetUsers");
            DropIndex("dbo.rests", new[] { "person_Id" });
            CreateTable(
                "dbo.restApplicationUsers",
                c => new
                    {
                        rest_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.rest_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.rests", t => t.rest_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.rest_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "email", c => c.String());
            DropColumn("dbo.rests", "person_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.rests", "person_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.restApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.restApplicationUsers", "rest_Id", "dbo.rests");
            DropIndex("dbo.restApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.restApplicationUsers", new[] { "rest_Id" });
            AlterColumn("dbo.AspNetUsers", "email", c => c.String(maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String());
            DropTable("dbo.restApplicationUsers");
            CreateIndex("dbo.rests", "person_Id");
            AddForeignKey("dbo.rests", "person_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
