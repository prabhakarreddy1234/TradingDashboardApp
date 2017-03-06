namespace TradingDashborad.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exchanges",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDeleted = c.Boolean(nullable: false),
                        LastModifiedBy = c.Guid(nullable: false),
                        LastModifiedDate = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.Trades",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Contract = c.String(),
                        Symbol = c.String(),
                        Volume = c.Long(nullable: false),
                        Type = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDeleted = c.Boolean(nullable: false),
                        LastModifiedBy = c.Guid(nullable: false),
                        LastModifiedDate = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TradeExchanges",
                c => new
                    {
                        Trade_Id = c.Guid(nullable: false),
                        Exchange_Code = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Trade_Id, t.Exchange_Code })
                .ForeignKey("dbo.Trades", t => t.Trade_Id, cascadeDelete: true)
                .ForeignKey("dbo.Exchanges", t => t.Exchange_Code, cascadeDelete: true)
                .Index(t => t.Trade_Id)
                .Index(t => t.Exchange_Code);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TradeExchanges", "Exchange_Code", "dbo.Exchanges");
            DropForeignKey("dbo.TradeExchanges", "Trade_Id", "dbo.Trades");
            DropIndex("dbo.TradeExchanges", new[] { "Exchange_Code" });
            DropIndex("dbo.TradeExchanges", new[] { "Trade_Id" });
            DropTable("dbo.TradeExchanges");
            DropTable("dbo.Trades");
            DropTable("dbo.Exchanges");
        }
    }
}
