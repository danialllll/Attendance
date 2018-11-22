namespace AttendanceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class someDataAnnotationaddedMakingNotMappedSomeField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.AspNetUsers", "lastName", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.AspNetUsers", "positionName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "address", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.AspNetUsers", "cellPhone", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "birthDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.AspNetUsers", "gender", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.AspNetUsers", "picPath", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "picPath", c => c.String());
            AlterColumn("dbo.AspNetUsers", "gender", c => c.String());
            AlterColumn("dbo.AspNetUsers", "birthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "cellPhone", c => c.String());
            AlterColumn("dbo.AspNetUsers", "address", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String());
            AlterColumn("dbo.AspNetUsers", "positionName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "lastName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "name", c => c.String());
        }
    }
}
