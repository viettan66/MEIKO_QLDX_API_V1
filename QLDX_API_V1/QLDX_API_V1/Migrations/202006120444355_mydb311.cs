namespace QLDX_API_V1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb311 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DX0060", "trangThai", c => c.Boolean());
            AlterColumn("dbo.DX0061", "DX0001_ID", c => c.String(maxLength: 50));
            CreateIndex("dbo.DX0061", "DX0001_ID");
            AddForeignKey("dbo.DX0061", "DX0001_ID", "dbo.DX0001", "DX0001_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DX0061", "DX0001_ID", "dbo.DX0001");
            DropIndex("dbo.DX0061", new[] { "DX0001_ID" });
            AlterColumn("dbo.DX0061", "DX0001_ID", c => c.String());
            DropColumn("dbo.DX0060", "trangThai");
        }
    }
}
