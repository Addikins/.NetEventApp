namespace EventApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionsForUserEventsAndGenres : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserEvents", "Artist_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserEvents", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.UserEvents", new[] { "Artist_Id" });
            DropIndex("dbo.UserEvents", new[] { "Genre_Id" });
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.UserEvents", "Venue", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.UserEvents", "Artist_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserEvents", "Genre_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.UserEvents", "Artist_Id");
            CreateIndex("dbo.UserEvents", "Genre_Id");
            AddForeignKey("dbo.UserEvents", "Artist_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserEvents", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserEvents", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.UserEvents", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserEvents", new[] { "Genre_Id" });
            DropIndex("dbo.UserEvents", new[] { "Artist_Id" });
            AlterColumn("dbo.UserEvents", "Genre_Id", c => c.Byte());
            AlterColumn("dbo.UserEvents", "Artist_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.UserEvents", "Venue", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
            CreateIndex("dbo.UserEvents", "Genre_Id");
            CreateIndex("dbo.UserEvents", "Artist_Id");
            AddForeignKey("dbo.UserEvents", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.UserEvents", "Artist_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
