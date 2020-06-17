namespace QLDX_API_V1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb33 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DX0011", "gioDon", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DX0011", "gioDon");
        }
    }
}
