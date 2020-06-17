namespace QLDX_API_V1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb14 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DX0070", "timeMin", c => c.Time(precision: 7));
            AlterColumn("dbo.DX0070", "timeMax", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DX0070", "timeMax", c => c.DateTime());
            AlterColumn("dbo.DX0070", "timeMin", c => c.DateTime());
        }
    }
}
