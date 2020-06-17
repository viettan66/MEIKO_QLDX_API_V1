namespace QLDX_API_V1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb18 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DX0001", "A0028_ID", c => c.String());
            AddColumn("dbo.DX0001", "A0002_ID", c => c.String());
            AddColumn("dbo.DX0001", "hoVaTen", c => c.String());
            AddColumn("dbo.DX0001", "A0016_ID", c => c.String());
            AddColumn("dbo.DX0001", "A0022_ID", c => c.String());
            AddColumn("dbo.DX0001", "A0032_ID", c => c.String());
            AddColumn("dbo.DX0001", "maForm", c => c.String());
            AddColumn("dbo.DX0001", "ngayTao", c => c.String());
            AddColumn("dbo.DX0001", "noiDungCongViec", c => c.String());
            AddColumn("dbo.DX0001", "daXoa", c => c.Boolean());
            AddColumn("dbo.DX0001", "tinhtrang", c => c.Int());
            AddColumn("dbo.DX0001", "T001C", c => c.String());
            AddColumn("dbo.DX0001", "T002C", c => c.String());
            AddColumn("dbo.DX0001", "T003C", c => c.String());
            AddColumn("dbo.DX0001", "T004C", c => c.String());
            AddColumn("dbo.DX0001", "T005C", c => c.String());
            AddColumn("dbo.DX0001", "T006C", c => c.String());
            AddColumn("dbo.DX0001", "T007C", c => c.String());
            AddColumn("dbo.DX0001", "T008C", c => c.String());
            AddColumn("dbo.DX0001", "T009C", c => c.String());
            AddColumn("dbo.DX0001", "T010C", c => c.String());
            AddColumn("dbo.DX0001", "T011C", c => c.String());
            AddColumn("dbo.DX0001", "T012C", c => c.String());
            AddColumn("dbo.DX0001", "T013C", c => c.String());
            AddColumn("dbo.DX0001", "T014C", c => c.String());
            AddColumn("dbo.DX0001", "T015C", c => c.String());
            AddColumn("dbo.DX0001", "T016C", c => c.String());
            AddColumn("dbo.DX0001", "T017C", c => c.String());
            AddColumn("dbo.DX0001", "T018C", c => c.String());
            AddColumn("dbo.DX0001", "T019C", c => c.String());
            AddColumn("dbo.DX0001", "T020C", c => c.String());
            AddColumn("dbo.DX0001", "T021C", c => c.String());
            AddColumn("dbo.DX0001", "T022C", c => c.String());
            AddColumn("dbo.DX0001", "T023C", c => c.String());
            AddColumn("dbo.DX0001", "T024C", c => c.String());
            AddColumn("dbo.DX0001", "T025C", c => c.String());
            AddColumn("dbo.DX0001", "T026C", c => c.String());
            AddColumn("dbo.DX0001", "T027C", c => c.String());
            AddColumn("dbo.DX0001", "T028C", c => c.String());
            AddColumn("dbo.DX0001", "T029C", c => c.String());
            AddColumn("dbo.DX0001", "T030C", c => c.String());
            AddColumn("dbo.DX0001", "T097C", c => c.String());
            AddColumn("dbo.DX0001", "T098C", c => c.String());
            AddColumn("dbo.DX0001", "T099C", c => c.String());
            AddColumn("dbo.DX0001", "T100C", c => c.String());
            AlterColumn("dbo.DX0001", "trangThai", c => c.Int());
            DropColumn("dbo.DX0001", "hoTen");
            DropColumn("dbo.DX0001", "maNhanSu");
            DropColumn("dbo.DX0001", "mayLe");
            DropColumn("dbo.DX0001", "diDong");
            DropColumn("dbo.DX0001", "capBac");
            DropColumn("dbo.DX0001", "boPhan");
            DropColumn("dbo.DX0001", "thoiGianBatDauSuDung");
            DropColumn("dbo.DX0001", "lyDoThayDoi");
            DropColumn("dbo.DX0001", "ghiChu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DX0001", "ghiChu", c => c.String());
            AddColumn("dbo.DX0001", "lyDoThayDoi", c => c.String());
            AddColumn("dbo.DX0001", "thoiGianBatDauSuDung", c => c.DateTime());
            AddColumn("dbo.DX0001", "boPhan", c => c.String());
            AddColumn("dbo.DX0001", "capBac", c => c.String());
            AddColumn("dbo.DX0001", "diDong", c => c.String());
            AddColumn("dbo.DX0001", "mayLe", c => c.String());
            AddColumn("dbo.DX0001", "maNhanSu", c => c.String());
            AddColumn("dbo.DX0001", "hoTen", c => c.String());
            AlterColumn("dbo.DX0001", "trangThai", c => c.Boolean());
            DropColumn("dbo.DX0001", "T100C");
            DropColumn("dbo.DX0001", "T099C");
            DropColumn("dbo.DX0001", "T098C");
            DropColumn("dbo.DX0001", "T097C");
            DropColumn("dbo.DX0001", "T030C");
            DropColumn("dbo.DX0001", "T029C");
            DropColumn("dbo.DX0001", "T028C");
            DropColumn("dbo.DX0001", "T027C");
            DropColumn("dbo.DX0001", "T026C");
            DropColumn("dbo.DX0001", "T025C");
            DropColumn("dbo.DX0001", "T024C");
            DropColumn("dbo.DX0001", "T023C");
            DropColumn("dbo.DX0001", "T022C");
            DropColumn("dbo.DX0001", "T021C");
            DropColumn("dbo.DX0001", "T020C");
            DropColumn("dbo.DX0001", "T019C");
            DropColumn("dbo.DX0001", "T018C");
            DropColumn("dbo.DX0001", "T017C");
            DropColumn("dbo.DX0001", "T016C");
            DropColumn("dbo.DX0001", "T015C");
            DropColumn("dbo.DX0001", "T014C");
            DropColumn("dbo.DX0001", "T013C");
            DropColumn("dbo.DX0001", "T012C");
            DropColumn("dbo.DX0001", "T011C");
            DropColumn("dbo.DX0001", "T010C");
            DropColumn("dbo.DX0001", "T009C");
            DropColumn("dbo.DX0001", "T008C");
            DropColumn("dbo.DX0001", "T007C");
            DropColumn("dbo.DX0001", "T006C");
            DropColumn("dbo.DX0001", "T005C");
            DropColumn("dbo.DX0001", "T004C");
            DropColumn("dbo.DX0001", "T003C");
            DropColumn("dbo.DX0001", "T002C");
            DropColumn("dbo.DX0001", "T001C");
            DropColumn("dbo.DX0001", "tinhtrang");
            DropColumn("dbo.DX0001", "daXoa");
            DropColumn("dbo.DX0001", "noiDungCongViec");
            DropColumn("dbo.DX0001", "ngayTao");
            DropColumn("dbo.DX0001", "maForm");
            DropColumn("dbo.DX0001", "A0032_ID");
            DropColumn("dbo.DX0001", "A0022_ID");
            DropColumn("dbo.DX0001", "A0016_ID");
            DropColumn("dbo.DX0001", "hoVaTen");
            DropColumn("dbo.DX0001", "A0002_ID");
            DropColumn("dbo.DX0001", "A0028_ID");
        }
    }
}
