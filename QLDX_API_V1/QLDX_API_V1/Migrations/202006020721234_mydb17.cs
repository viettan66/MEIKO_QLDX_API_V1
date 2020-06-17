namespace QLDX_API_V1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DX0050", "loaiThe", c => c.String());
            AddColumn("dbo.DX0050", "hangTaxi", c => c.String());
            AddColumn("dbo.DX0050", "ngayPhatHanh", c => c.DateTime());
            AddColumn("dbo.DX0050", "ngayHetHan", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DX0050", "ngayHetHan");
            DropColumn("dbo.DX0050", "ngayPhatHanh");
            DropColumn("dbo.DX0050", "hangTaxi");
            DropColumn("dbo.DX0050", "loaiThe");
        }
    }
}
