namespace FluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 2000),
                        Level = c.Int(nullable: false),
                        FullPrice = c.Single(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Covers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseTags",
                c => new
                    {
                        Course_Id = c.Int(nullable: false),
                        Tag_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_Id, t.Tag_Id })
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .Index(t => t.Course_Id)
                .Index(t => t.Tag_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseTags", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.CourseTags", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Covers", "Id", "dbo.Courses");
            DropForeignKey("dbo.Courses", "AuthorId", "dbo.Authors");
            DropIndex("dbo.CourseTags", new[] { "Tag_Id" });
            DropIndex("dbo.CourseTags", new[] { "Course_Id" });
            DropIndex("dbo.Covers", new[] { "Id" });
            DropIndex("dbo.Courses", new[] { "AuthorId" });
            DropTable("dbo.CourseTags");
            DropTable("dbo.Tags");
            DropTable("dbo.Covers");
            DropTable("dbo.Courses");
            DropTable("dbo.Authors");
        }
    }
}
