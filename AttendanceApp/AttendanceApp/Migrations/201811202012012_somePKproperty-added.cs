namespace AttendanceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somePKpropertyadded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "position_Id", "dbo.positions");
            DropIndex("dbo.AspNetUsers", new[] { "position_Id" });
            RenameColumn(table: "dbo.AspNetUsers", name: "position_Id", newName: "positionId");
            AddColumn("dbo.rests", "personId", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "email", c => c.String());
            AlterColumn("dbo.AspNetUsers", "positionId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "positionId");
            AddForeignKey("dbo.AspNetUsers", "positionId", "dbo.positions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "positionId", "dbo.positions");
            DropIndex("dbo.AspNetUsers", new[] { "positionId" });
            AlterColumn("dbo.AspNetUsers", "positionId", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "email", c => c.String(maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String());
            DropColumn("dbo.rests", "personId");
            RenameColumn(table: "dbo.AspNetUsers", name: "positionId", newName: "position_Id");
            CreateIndex("dbo.AspNetUsers", "position_Id");
            AddForeignKey("dbo.AspNetUsers", "position_Id", "dbo.positions", "Id");
        }
    }
}
