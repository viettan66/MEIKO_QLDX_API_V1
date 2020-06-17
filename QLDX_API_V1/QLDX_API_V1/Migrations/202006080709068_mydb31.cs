namespace QLDX_API_V1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DX0020", "thoiGianSuDung", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DX0020", "thoiGianSuDung");
        }
    }
}
