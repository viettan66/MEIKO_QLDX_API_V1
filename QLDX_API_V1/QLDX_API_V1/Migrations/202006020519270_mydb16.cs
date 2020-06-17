namespace QLDX_API_V1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb16 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DX0011", "DX0070_DX0070_ID", "dbo.DX0070");
            DropIndex("dbo.DX0011", new[] { "DX0070_DX0070_ID" });
            DropColumn("dbo.DX0011", "DX0070_DX0070_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DX0011", "DX0070_DX0070_ID", c => c.String(maxLength: 50));
            CreateIndex("dbo.DX0011", "DX0070_DX0070_ID");
            AddForeignKey("dbo.DX0011", "DX0070_DX0070_ID", "dbo.DX0070", "DX0070_ID");
        }
    }
}
