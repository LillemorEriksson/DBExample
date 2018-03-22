namespace DBExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Students : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Teacher_Id", c => c.Int());
            AddColumn("dbo.Students", "Course_Id", c => c.Int());
            CreateIndex("dbo.Courses", "Teacher_Id");
            CreateIndex("dbo.Students", "Course_Id");
            AddForeignKey("dbo.Students", "Course_Id", "dbo.Courses", "Id");
            AddForeignKey("dbo.Courses", "Teacher_Id", "dbo.Teachers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Students", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Students", new[] { "Course_Id" });
            DropIndex("dbo.Courses", new[] { "Teacher_Id" });
            DropColumn("dbo.Students", "Course_Id");
            DropColumn("dbo.Courses", "Teacher_Id");
        }
    }
}
