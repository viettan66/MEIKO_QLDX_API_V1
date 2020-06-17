namespace QLDX_API_V1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DX0010D", "thuTu", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DX0010D", "thuTu");
        }
    }
}
