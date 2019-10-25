namespace CommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbsetsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Code = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductTranslates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.LanguageId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductTranslates", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductTranslates", "LanguageId", "dbo.Languages");
            DropIndex("dbo.ProductTranslates", new[] { "ProductId" });
            DropIndex("dbo.ProductTranslates", new[] { "LanguageId" });
            DropTable("dbo.ProductTranslates");
            DropTable("dbo.Products");
            DropTable("dbo.Languages");
        }
    }
}
