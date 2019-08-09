namespace CookingCurator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecipeAdd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Album", "ArtistId", "dbo.Artist");
            DropForeignKey("dbo.Track", "AlbumId", "dbo.Album");
            DropForeignKey("dbo.Track", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.Customer", "Employee_EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Employee", "Employee2_EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Invoice", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.InvoiceLine", "InvoiceId", "dbo.Invoice");
            DropForeignKey("dbo.InvoiceLine", "TrackId", "dbo.Track");
            DropForeignKey("dbo.Track", "MediaTypeId", "dbo.MediaType");
            DropForeignKey("dbo.PlaylistTracks", "Playlist_PlaylistId", "dbo.Playlist");
            DropForeignKey("dbo.PlaylistTracks", "Track_TrackId", "dbo.Track");
            DropIndex("dbo.Track", new[] { "AlbumId" });
            DropIndex("dbo.Track", new[] { "MediaTypeId" });
            DropIndex("dbo.Track", new[] { "GenreId" });
            DropIndex("dbo.Album", new[] { "ArtistId" });
            DropIndex("dbo.InvoiceLine", new[] { "InvoiceId" });
            DropIndex("dbo.InvoiceLine", new[] { "TrackId" });
            DropIndex("dbo.Invoice", new[] { "CustomerId" });
            DropIndex("dbo.Customer", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Employee", new[] { "Employee2_EmployeeId" });
            DropIndex("dbo.PlaylistTracks", new[] { "Playlist_PlaylistId" });
            DropIndex("dbo.PlaylistTracks", new[] { "Track_TrackId" });
            CreateTable(
                "dbo.RECIPES",
                c => new
                    {
                        recipe_ID = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        instructions = c.String(),
                        author = c.String(),
                    })
                .PrimaryKey(t => t.recipe_ID);
            
            DropTable("dbo.Track");
            DropTable("dbo.Album");
            DropTable("dbo.Artist");
            DropTable("dbo.Genre");
            DropTable("dbo.InvoiceLine");
            DropTable("dbo.Invoice");
            DropTable("dbo.Customer");
            DropTable("dbo.Employee");
            DropTable("dbo.MediaType");
            DropTable("dbo.Playlist");
            DropTable("dbo.PlaylistTracks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PlaylistTracks",
                c => new
                    {
                        Playlist_PlaylistId = c.Int(nullable: false),
                        Track_TrackId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Playlist_PlaylistId, t.Track_TrackId });
            
            CreateTable(
                "dbo.Playlist",
                c => new
                    {
                        PlaylistId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 120),
                    })
                .PrimaryKey(t => t.PlaylistId);
            
            CreateTable(
                "dbo.MediaType",
                c => new
                    {
                        MediaTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 120),
                    })
                .PrimaryKey(t => t.MediaTypeId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        Title = c.String(maxLength: 30),
                        ReportsTo = c.Int(),
                        BirthDate = c.DateTime(),
                        HireDate = c.DateTime(),
                        Address = c.String(maxLength: 70),
                        City = c.String(maxLength: 40),
                        State = c.String(maxLength: 40),
                        Country = c.String(maxLength: 40),
                        PostalCode = c.String(maxLength: 10),
                        Phone = c.String(maxLength: 24),
                        Fax = c.String(maxLength: 24),
                        Email = c.String(maxLength: 60),
                        Employee2_EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 40),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Company = c.String(maxLength: 80),
                        Address = c.String(maxLength: 70),
                        City = c.String(maxLength: 40),
                        State = c.String(maxLength: 40),
                        Country = c.String(maxLength: 40),
                        PostalCode = c.String(maxLength: 10),
                        Phone = c.String(maxLength: 24),
                        Fax = c.String(maxLength: 24),
                        Email = c.String(nullable: false, maxLength: 60),
                        SupportRepId = c.Int(),
                        Employee_EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        InvoiceDate = c.DateTime(nullable: false),
                        BillingAddress = c.String(maxLength: 70),
                        BillingCity = c.String(maxLength: 40),
                        BillingState = c.String(maxLength: 40),
                        BillingCountry = c.String(maxLength: 40),
                        BillingPostalCode = c.String(maxLength: 10),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.InvoiceId);
            
            CreateTable(
                "dbo.InvoiceLine",
                c => new
                    {
                        InvoiceLineId = c.Int(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                        TrackId = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceLineId);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 120),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Artist",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 120),
                    })
                .PrimaryKey(t => t.ArtistId);
            
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 160),
                        ArtistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumId);
            
            CreateTable(
                "dbo.Track",
                c => new
                    {
                        TrackId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        AlbumId = c.Int(),
                        MediaTypeId = c.Int(nullable: false),
                        GenreId = c.Int(),
                        Composer = c.String(maxLength: 220),
                        Milliseconds = c.Int(nullable: false),
                        Bytes = c.Int(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.TrackId);
            
            DropTable("dbo.RECIPES");
            CreateIndex("dbo.PlaylistTracks", "Track_TrackId");
            CreateIndex("dbo.PlaylistTracks", "Playlist_PlaylistId");
            CreateIndex("dbo.Employee", "Employee2_EmployeeId");
            CreateIndex("dbo.Customer", "Employee_EmployeeId");
            CreateIndex("dbo.Invoice", "CustomerId");
            CreateIndex("dbo.InvoiceLine", "TrackId");
            CreateIndex("dbo.InvoiceLine", "InvoiceId");
            CreateIndex("dbo.Album", "ArtistId");
            CreateIndex("dbo.Track", "GenreId");
            CreateIndex("dbo.Track", "MediaTypeId");
            CreateIndex("dbo.Track", "AlbumId");
            AddForeignKey("dbo.PlaylistTracks", "Track_TrackId", "dbo.Track", "TrackId", cascadeDelete: true);
            AddForeignKey("dbo.PlaylistTracks", "Playlist_PlaylistId", "dbo.Playlist", "PlaylistId", cascadeDelete: true);
            AddForeignKey("dbo.Track", "MediaTypeId", "dbo.MediaType", "MediaTypeId", cascadeDelete: true);
            AddForeignKey("dbo.InvoiceLine", "TrackId", "dbo.Track", "TrackId");
            AddForeignKey("dbo.InvoiceLine", "InvoiceId", "dbo.Invoice", "InvoiceId", cascadeDelete: true);
            AddForeignKey("dbo.Invoice", "CustomerId", "dbo.Customer", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.Employee", "Employee2_EmployeeId", "dbo.Employee", "EmployeeId");
            AddForeignKey("dbo.Customer", "Employee_EmployeeId", "dbo.Employee", "EmployeeId");
            AddForeignKey("dbo.Track", "GenreId", "dbo.Genre", "GenreId");
            AddForeignKey("dbo.Track", "AlbumId", "dbo.Album", "AlbumId");
            AddForeignKey("dbo.Album", "ArtistId", "dbo.Artist", "ArtistId", cascadeDelete: true);
        }
    }
}
