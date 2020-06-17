namespace QLDX_API_V1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb30 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DX0020", "DX0010_ID", c => c.String(maxLength: 50));
            CreateIndex("dbo.DX0020", "DX0010_ID");
            AddForeignKey("dbo.DX0020", "DX0010_ID", "dbo.DX0010", "DX0010_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DX0020", "DX0010_ID", "dbo.DX0010");
            DropIndex("dbo.DX0020", new[] { "DX0010_ID" });
            DropColumn("dbo.DX0020", "DX0010_ID");
        }
    }
}
