namespace ДвижокНовостейЗМ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVisitsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VisitsTables",
                c => new
                    {
                        Url = c.String(nullable: false, maxLength: 128),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Url);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VisitsTables");
        }
    }
}
