namespace QLDX_API_V1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb32 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DX0060", "DX0070_ID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DX0060", "DX0070_ID");
        }
    }
}
