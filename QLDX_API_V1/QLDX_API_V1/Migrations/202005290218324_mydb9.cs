namespace QLDX_API_V1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DX0001",
                c => new
                    {
                        DX0001_ID = c.String(nullable: false, maxLength: 50),
                        hoTen = c.String(),
                        maNhanSu = c.String(),
                        mayLe = c.String(),
                        diDong = c.String(),
                        capBac = c.String(),
                        boPhan = c.String(),
                        DX0011_ID = c.String(maxLength: 50),
                        DX0010_ID = c.String(maxLength: 50),
                        DX0070_ID = c.String(maxLength: 50),
                        thoiGianBatDauSuDung = c.DateTime(),
                        lyDoThayDoi = c.String(),
                        ghiChu = c.String(),
                        trangThai = c.Boolean(),
                    })
                .PrimaryKey(t => t.DX0001_ID)
                .ForeignKey("dbo.DX0010", t => t.DX0010_ID)
                .ForeignKey("dbo.DX0011", t => t.DX0011_ID)
                .ForeignKey("dbo.DX0070", t => t.DX0070_ID)
                .Index(t => t.DX0011_ID)
                .Index(t => t.DX0010_ID)
                .Index(t => t.DX0070_ID);
            
            CreateTable(
                "dbo.DX0010",
                c => new
                    {
                        DX0010_ID = c.String(nullable: false, maxLength: 50),
                        maTuyenXe = c.String(),
                        tenTuyenXe = c.String(),
                        bienSoXe = c.String(),
                        tenLaiXe = c.String(),
                        mobile = c.String(),
                        ghiChu = c.String(),
                        trangThai = c.Boolean(),
                        thuTu = c.Int(),
                    })
                .PrimaryKey(t => t.DX0010_ID);
            
            CreateTable(
                "dbo.DX0010D",
                c => new
                    {
                        DX0010D_ID = c.String(nullable: false, maxLength: 50),
                        DX0010_ID = c.String(maxLength: 50),
                        DX0011_ID = c.String(maxLength: 50),
                        ghiChu = c.String(),
                    })
                .PrimaryKey(t => t.DX0010D_ID)
                .ForeignKey("dbo.DX0010", t => t.DX0010_ID)
                .ForeignKey("dbo.DX0011", t => t.DX0011_ID)
                .Index(t => t.DX0010_ID)
                .Index(t => t.DX0011_ID);
            
            CreateTable(
                "dbo.DX0011",
                c => new
                    {
                        DX0011_ID = c.String(nullable: false, maxLength: 50),
                        DX0013_ID = c.String(maxLength: 50),
                        maDiemDon = c.String(),
                        tenDiemDon = c.String(),
                        ghiChu = c.String(),
                        trangThai = c.Boolean(),
                        taxi = c.Boolean(),
                        thuTu = c.Int(),
                        lat = c.Single(),
                        lng = c.Single(),
                    })
                .PrimaryKey(t => t.DX0011_ID)
                .ForeignKey("dbo.DX0013", t => t.DX0013_ID)
                .Index(t => t.DX0013_ID);
            
            CreateTable(
                "dbo.DX0013",
                c => new
                    {
                        DX0013_ID = c.String(nullable: false, maxLength: 50),
                        DX0011_ID = c.String(),
                        maDiemTaxi = c.String(),
                        tenDiemTaxi = c.String(),
                        ghiChu = c.String(),
                        lat = c.Single(),
                        lng = c.Single(),
                        trangThai = c.Boolean(),
                    })
                .PrimaryKey(t => t.DX0013_ID);
            
            CreateTable(
                "dbo.DX0020",
                c => new
                    {
                        DX0020_ID = c.String(nullable: false, maxLength: 50),
                        DX0011_ID = c.String(maxLength: 50),
                        manhansu = c.String(),
                        hodem = c.String(),
                        ten = c.String(),
                        ngaysinh = c.DateTime(),
                        gioitinh = c.Boolean(),
                        diachithuongtru = c.String(),
                        diachitamtru = c.String(),
                        cmtnd_so = c.String(),
                        phong_id = c.String(),
                        ban_id = c.String(),
                        dienthoai_didong = c.String(),
                        email = c.String(),
                        chucvu = c.String(),
                        capbac = c.String(),
                        thetu_id = c.String(),
                        trangThai = c.Int(),
                    })
                .PrimaryKey(t => t.DX0020_ID)
                .ForeignKey("dbo.DX0011", t => t.DX0011_ID)
                .Index(t => t.DX0011_ID);
            
            CreateTable(
                "dbo.DX0070",
                c => new
                    {
                        DX0070_ID = c.String(nullable: false, maxLength: 50),
                        thoiGian = c.DateTime(),
                        ghiChu = c.String(),
                    })
                .PrimaryKey(t => t.DX0070_ID);
            
            CreateTable(
                "dbo.DX0012",
                c => new
                    {
                        DX0012_ID = c.String(nullable: false, maxLength: 50),
                        DX0010_ID = c.String(maxLength: 50),
                        bienSoXe = c.String(),
                        tenLaiXe = c.String(),
                        mobile = c.String(),
                        soLuongGhe = c.Int(),
                        ghiChu = c.String(),
                        trangThai = c.Boolean(),
                    })
                .PrimaryKey(t => t.DX0012_ID)
                .ForeignKey("dbo.DX0010", t => t.DX0010_ID)
                .Index(t => t.DX0010_ID);
            
            CreateTable(
                "dbo.DX0050",
                c => new
                    {
                        DX0050_ID = c.String(nullable: false, maxLength: 50),
                        maThe = c.String(),
                        soThe = c.String(),
                        ghiChu = c.String(),
                        trangThai = c.Boolean(),
                    })
                .PrimaryKey(t => t.DX0050_ID);
            
            CreateTable(
                "dbo.DX0060",
                c => new
                    {
                        DX0060_ID = c.String(nullable: false, maxLength: 50),
                        DX0050_ID = c.String(maxLength: 50),
                        thoiGian = c.DateTime(),
                        ghiChu = c.String(),
                    })
                .PrimaryKey(t => t.DX0060_ID)
                .ForeignKey("dbo.DX0050", t => t.DX0050_ID)
                .Index(t => t.DX0050_ID);
            
            CreateTable(
                "dbo.DX0061",
                c => new
                    {
                        DX0061_ID = c.String(nullable: false, maxLength: 50),
                        DX0060_ID = c.String(maxLength: 50),
                        DX0001_ID = c.String(),
                        ghiChu = c.String(),
                    })
                .PrimaryKey(t => t.DX0061_ID)
                .ForeignKey("dbo.DX0060", t => t.DX0060_ID)
                .Index(t => t.DX0060_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DX0061", "DX0060_ID", "dbo.DX0060");
            DropForeignKey("dbo.DX0060", "DX0050_ID", "dbo.DX0050");
            DropForeignKey("dbo.DX0012", "DX0010_ID", "dbo.DX0010");
            DropForeignKey("dbo.DX0001", "DX0070_ID", "dbo.DX0070");
            DropForeignKey("dbo.DX0001", "DX0011_ID", "dbo.DX0011");
            DropForeignKey("dbo.DX0020", "DX0011_ID", "dbo.DX0011");
            DropForeignKey("dbo.DX0011", "DX0013_ID", "dbo.DX0013");
            DropForeignKey("dbo.DX0010D", "DX0011_ID", "dbo.DX0011");
            DropForeignKey("dbo.DX0010D", "DX0010_ID", "dbo.DX0010");
            DropForeignKey("dbo.DX0001", "DX0010_ID", "dbo.DX0010");
            DropIndex("dbo.DX0061", new[] { "DX0060_ID" });
            DropIndex("dbo.DX0060", new[] { "DX0050_ID" });
            DropIndex("dbo.DX0012", new[] { "DX0010_ID" });
            DropIndex("dbo.DX0020", new[] { "DX0011_ID" });
            DropIndex("dbo.DX0011", new[] { "DX0013_ID" });
            DropIndex("dbo.DX0010D", new[] { "DX0011_ID" });
            DropIndex("dbo.DX0010D", new[] { "DX0010_ID" });
            DropIndex("dbo.DX0001", new[] { "DX0070_ID" });
            DropIndex("dbo.DX0001", new[] { "DX0010_ID" });
            DropIndex("dbo.DX0001", new[] { "DX0011_ID" });
            DropTable("dbo.DX0061");
            DropTable("dbo.DX0060");
            DropTable("dbo.DX0050");
            DropTable("dbo.DX0012");
            DropTable("dbo.DX0070");
            DropTable("dbo.DX0020");
            DropTable("dbo.DX0013");
            DropTable("dbo.DX0011");
            DropTable("dbo.DX0010D");
            DropTable("dbo.DX0010");
            DropTable("dbo.DX0001");
        }
    }
}
