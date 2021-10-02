namespace Test.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableExpense : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(nullable: false),
                        Fees = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExpenseDate = c.DateTime(nullable: false),
                        Note = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Expenses");
        }
    }
}
