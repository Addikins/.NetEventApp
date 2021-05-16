namespace EventApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropertiesToUserEvent : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserEvents", name: "Artist_Id", newName: "ArtistId");
            RenameColumn(table: "dbo.UserEvents", name: "Genre_Id", newName: "GenreId");
            RenameIndex(table: "dbo.UserEvents", name: "IX_Artist_Id", newName: "IX_ArtistId");
            RenameIndex(table: "dbo.UserEvents", name: "IX_Genre_Id", newName: "IX_GenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UserEvents", name: "IX_GenreId", newName: "IX_Genre_Id");
            RenameIndex(table: "dbo.UserEvents", name: "IX_ArtistId", newName: "IX_Artist_Id");
            RenameColumn(table: "dbo.UserEvents", name: "GenreId", newName: "Genre_Id");
            RenameColumn(table: "dbo.UserEvents", name: "ArtistId", newName: "Artist_Id");
        }
    }
}
