namespace CookingCurator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.TrackId)
                .ForeignKey("dbo.Album", t => t.AlbumId)
                .ForeignKey("dbo.Genre", t => t.GenreId)
                .ForeignKey("dbo.MediaType", t => t.MediaTypeId, cascadeDelete: true)
                .Index(t => t.AlbumId)
                .Index(t => t.MediaTypeId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 160),
                        ArtistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.Artist", t => t.ArtistId, cascadeDelete: true)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.Artist",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 120),
                    })
                .PrimaryKey(t => t.ArtistId);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 120),
                    })
                .PrimaryKey(t => t.GenreId);
            
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
                .PrimaryKey(t => t.InvoiceLineId)
                .ForeignKey("dbo.Invoice", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Track", t => t.TrackId)
                .Index(t => t.InvoiceId)
                .Index(t => t.TrackId);
            
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
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
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
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Employee", t => t.Employee_EmployeeId)
                .Index(t => t.Employee_EmployeeId);
            
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
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Employee", t => t.Employee2_EmployeeId)
                .Index(t => t.Employee2_EmployeeId);
            
            CreateTable(
                "dbo.MediaType",
                c => new
                    {
                        MediaTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 120),
                    })
                .PrimaryKey(t => t.MediaTypeId);
            
            CreateTable(
                "dbo.Playlist",
                c => new
                    {
                        PlaylistId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 120),
                    })
                .PrimaryKey(t => t.PlaylistId);
            
            CreateTable(
                "dbo.PlaylistTracks",
                c => new
                    {
                        Playlist_PlaylistId = c.Int(nullable: false),
                        Track_TrackId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Playlist_PlaylistId, t.Track_TrackId })
                .ForeignKey("dbo.Playlist", t => t.Playlist_PlaylistId, cascadeDelete: true)
                .ForeignKey("dbo.Track", t => t.Track_TrackId, cascadeDelete: true)
                .Index(t => t.Playlist_PlaylistId)
                .Index(t => t.Track_TrackId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlaylistTracks", "Track_TrackId", "dbo.Track");
            DropForeignKey("dbo.PlaylistTracks", "Playlist_PlaylistId", "dbo.Playlist");
            DropForeignKey("dbo.Track", "MediaTypeId", "dbo.MediaType");
            DropForeignKey("dbo.InvoiceLine", "TrackId", "dbo.Track");
            DropForeignKey("dbo.InvoiceLine", "InvoiceId", "dbo.Invoice");
            DropForeignKey("dbo.Invoice", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Employee", "Employee2_EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Customer", "Employee_EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Track", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.Track", "AlbumId", "dbo.Album");
            DropForeignKey("dbo.Album", "ArtistId", "dbo.Artist");
            DropIndex("dbo.PlaylistTracks", new[] { "Track_TrackId" });
            DropIndex("dbo.PlaylistTracks", new[] { "Playlist_PlaylistId" });
            DropIndex("dbo.Employee", new[] { "Employee2_EmployeeId" });
            DropIndex("dbo.Customer", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Invoice", new[] { "CustomerId" });
            DropIndex("dbo.InvoiceLine", new[] { "TrackId" });
            DropIndex("dbo.InvoiceLine", new[] { "InvoiceId" });
            DropIndex("dbo.Album", new[] { "ArtistId" });
            DropIndex("dbo.Track", new[] { "GenreId" });
            DropIndex("dbo.Track", new[] { "MediaTypeId" });
            DropIndex("dbo.Track", new[] { "AlbumId" });
            DropTable("dbo.PlaylistTracks");
            DropTable("dbo.Playlist");
            DropTable("dbo.MediaType");
            DropTable("dbo.Employee");
            DropTable("dbo.Customer");
            DropTable("dbo.Invoice");
            DropTable("dbo.InvoiceLine");
            DropTable("dbo.Genre");
            DropTable("dbo.Artist");
            DropTable("dbo.Album");
            DropTable("dbo.Track");
        }
    }
}
