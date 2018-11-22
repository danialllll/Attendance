namespace AttendanceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class someAnnotationadded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.positions", "positionName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.positions", "positionName", c => c.String());
        }
    }
}
