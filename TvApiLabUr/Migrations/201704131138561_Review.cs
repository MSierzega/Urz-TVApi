namespace TvApiLabUr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Review : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        Rate = c.Short(nullable: false),
                        Movie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Reviews", new[] { "Movie_Id" });
            DropTable("dbo.Reviews");
        }
    }
}
