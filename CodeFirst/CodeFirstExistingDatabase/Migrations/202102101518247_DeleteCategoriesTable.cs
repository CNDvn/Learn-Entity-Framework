namespace CodeFirstExistingDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCategoriesTable : DbMigration
    {
        public override void Up()
        {
            //dùng để lưu dữ liệu tạm thời lỡ cần thì có mà sai. không có dụ tao xóa data dễ vậy đâu :))
            CreateTable(
                "dbo._Categories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);
            //lấy data chuẩn bị xóa bỏ vào 
            Sql("INSERT INTO _Categories (Name) SELECT Name FROM Categories");

            DropTable("dbo.Categories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO Categories (Name) SELECT Name FROM _Categories");

            DropTable("dbo._Categories");

        }
    }
}
