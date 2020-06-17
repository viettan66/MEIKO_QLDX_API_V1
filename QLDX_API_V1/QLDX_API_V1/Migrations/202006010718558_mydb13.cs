namespace QLDX_API_V1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DX0070", "tenKhungGio", c => c.String());
            AddColumn("dbo.DX0070", "timeMin", c => c.DateTime());
            AddColumn("dbo.DX0070", "timeMax", c => c.DateTime());
            AddColumn("dbo.DX0070", "trangThai", c => c.Boolean());
            DropColumn("dbo.DX0070", "thoiGian");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DX0070", "thoiGian", c => c.DateTime());
            DropColumn("dbo.DX0070", "trangThai");
            DropColumn("dbo.DX0070", "timeMax");
            DropColumn("dbo.DX0070", "timeMin");
            DropColumn("dbo.DX0070", "tenKhungGio");
        }
    }
}
