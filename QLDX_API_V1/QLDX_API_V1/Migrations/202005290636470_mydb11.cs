namespace QLDX_API_V1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DX0014",
                c => new
                    {
                        DX0014_ID = c.String(nullable: false, maxLength: 50),
                        tenDiaDanh = c.String(),
                        ghiChu = c.String(),
                        trangThai = c.Boolean(),
                    })
                .PrimaryKey(t => t.DX0014_ID);
            
            AddColumn("dbo.DX0011", "DX0014_ID", c => c.String(maxLength: 50));
            CreateIndex("dbo.DX0011", "DX0014_ID");
            AddForeignKey("dbo.DX0011", "DX0014_ID", "dbo.DX0014", "DX0014_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DX0011", "DX0014_ID", "dbo.DX0014");
            DropIndex("dbo.DX0011", new[] { "DX0014_ID" });
            DropColumn("dbo.DX0011", "DX0014_ID");
            DropTable("dbo.DX0014");
        }
    }
}
