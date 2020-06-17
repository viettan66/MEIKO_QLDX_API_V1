using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QLDX_API_V1.Models
{
    public class QLDX_DB:DbContext
    {
        public QLDX_DB() : base("DefaultConnection")
        {

        }
        public DbSet<DX0001> DX0001 { get; set; }
        public DbSet<DX0010> DX0010 { get; set; }
        public DbSet<DX0010D> DX0010D { get; set; }
        public DbSet<DX0011> DX0011 { get; set; }
        public DbSet<DX0012> DX0012 { get; set; }
        public DbSet<DX0020> DX0020 { get; set; }
       // public DbSet<DX0030> DX0030 { get; set; }
        public DbSet<DX0050> DX0050 { get; set; }
        public DbSet<DX0060> DX0060 { get; set; }
        public DbSet<DX0061> DX0061 { get; set; }
        public DbSet<DX0070> DX0070 { get; set; }
        public DbSet<DX0013> DX0013 { get; set; }
        public DbSet<DX0014> DX0014 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "Bảng tuyến xe"
    /// </summary>
    [Table("DX0010")]
    public class DX0010
    {
        [Key]
        [MaxLength(50)]
        public string DX0010_ID { get; set; }= Guid.NewGuid().ToString();
        public string maTuyenXe { get; set; }
        public string tenTuyenXe { get; set; }
        public string bienSoXe { get; set; }
        public string tenLaiXe { get; set; }
        public string mobile { get; set; }
        public string ghiChu { get; set; }
        public Nullable<bool> trangThai { get; set; }
        public Nullable<int> thuTu { get; set; }
        public Nullable<int> type { get; set; }
        public virtual ICollection<DX0010D> DX0010D { get; set; }
        public virtual ICollection<DX0001> DX0001 { get; set; }
        public virtual ICollection<DX0020> DX0020 { get; set; }
        public virtual ICollection<DX0012> DX0012 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "Chi tiết tuyến xe mapping"
    /// </summary>
    [Table("DX0010D")]
    public class DX0010D
    {
        [Key]
        [MaxLength(50)]
        public string DX0010D_ID { get; set; }= Guid.NewGuid().ToString();
        public string DX0010_ID { get; set; }
        public string DX0011_ID { get; set; }
        public string ghiChu { get; set; }
        public Nullable<int> thuTu{ get; set; }
        public virtual DX0011 DX0011 { get; set; }
        public virtual DX0010 DX0010 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "Điểm đón tuyến xe"
    /// </summary>
    [Table("DX0011")]
    public class DX0011
    {
        [Key]
        [MaxLength(50)]
        public string DX0011_ID { get; set; }= Guid.NewGuid().ToString();
        public string DX0013_ID { get; set; }
        public string DX0014_ID { get; set; }
        public string maDiemDon { get; set; }
        public string tenDiemDon { get; set; }
        public string ghiChu { get; set; }
        public string gioDon { get; set; }
        public Nullable<bool> trangThai { get; set; }
        public Nullable<bool> taxi { get; set; }
        public Nullable<int> thuTu { get; set; }
        public Nullable<float> lat { get; set; }
        public Nullable<float> lng { get; set; }
        public virtual ICollection< DX0010D> DX0010D { get; set; }
        public virtual  DX0014 DX0014 { get; set; }
        public virtual DX0013 DX0013 { get; set; }
        public virtual ICollection<DX0020> DX0020 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "Địa danh"
    /// </summary>
    [Table("DX0014")]
    public class DX0014
    {
        [Key]
        [MaxLength(50)]
        public string DX0014_ID { get; set; } = Guid.NewGuid().ToString();
        public string tenDiaDanh { get; set; }
        public string ghiChu { get; set; }
        public Nullable<bool> trangThai { get; set; }
        public virtual ICollection< DX0011> DX0011 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "Xe"
    /// </summary>
    [Table("DX0012")]
    public class DX0012
    {
        [Key]
        [MaxLength(50)]
        public string DX0012_ID { get; set; } = Guid.NewGuid().ToString();
        public string DX0010_ID { get; set; }
        public string bienSoXe { get; set; }
        public string tenLaiXe { get; set; }
        public string mobile { get; set; }
        public Nullable<int> soLuongGhe { get; set; }
        public string ghiChu { get; set; }
        public Nullable<bool> trangThai { get; set; }
        public virtual DX0010 DX0010 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "Điểm lên xe taxi"
    /// </summary>
    [Table("DX0013")]
    public class DX0013
    {
        [Key]
        [MaxLength(50)]
        public string DX0013_ID { get; set; } = Guid.NewGuid().ToString();
        public string DX0011_ID { get; set; }
        public string maDiemTaxi { get; set; }
        public string tenDiemTaxi { get; set; }
        public string ghiChu { get; set; }
        public Nullable<float> lat { get; set; }
        public Nullable<float> lng { get; set; }
        public Nullable<bool> trangThai { get; set; }
        public virtual ICollection< DX0011 >DX0011 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "Nhân viên đi xe"
    /// </summary>
    [Table("DX0020")]
    public class DX0020
    {
        [Key]
        [MaxLength(50)]
        public string DX0020_ID { get; set; } = Guid.NewGuid().ToString();
        public string DX0011_ID { get; set; }
        public string DX0010_ID { get; set; }
        public string manhansu { get; set; }
        public string hodem { get; set; }
        public string ten { get; set; }
        public Nullable<DateTime> ngaysinh { get; set; }
        public Nullable<bool> gioitinh { get; set; }
        public string diachithuongtru { get; set; }
        public string diachitamtru { get; set; }
        public string cmtnd_so { get; set; }
        public string phong_id { get; set; }
        public string ban_id { get; set; }
        public string dienthoai_didong { get; set; }
        public string email { get; set; }
        public string chucvu { get; set; }
        public string capbac { get; set; }
        public string thetu_id { get; set; }
        public string thoiGianSuDung { get; set; }
        public Nullable<int> trangThai { get; set; }
        public virtual DX0011 DX0011 { get; set; }
        public virtual DX0010 DX0010 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "Ca nhân viên"
    /// </summary>
    [Table("DX0030")]
    public class DX0030
    {
        [Key]
        [MaxLength(50)]
        public string DX0030_ID { get; set; } = Guid.NewGuid().ToString();
        public string manhansu { get; set; }
        public string n1 { get; set; }
        public string n2 { get; set; }
        public string n3 { get; set; }
        public string n4 { get; set; }
        public string n5 { get; set; }
        public string n6 { get; set; }
        public string n7 { get; set; }
        public string n8 { get; set; }
        public string n9 { get; set; }
        public string n10 { get; set; }
        public string n11 { get; set; }
        public string n12 { get; set; }
        public string n13 { get; set; }
        public string n14 { get; set; }
        public string n15 { get; set; }
        public string n16 { get; set; }
        public string n17 { get; set; }
        public string n18 { get; set; }
        public string n19 { get; set; }
        public string n20 { get; set; }
        public string n21 { get; set; }
        public string n22 { get; set; }
        public string n23 { get; set; }
        public string n24 { get; set; }
        public string n25 { get; set; }
        public string n26 { get; set; }
        public string n27 { get; set; }
        public string n28 { get; set; }
        public string n29 { get; set; }
        public string n30 { get; set; }
        public string n31 { get; set; }
    }

    /// <summary>
    /// Đây là bảng "Yêu cầu xe"
    /// </summary>
    [Table("DX0001")]
    public class DX0001
    {
        [Key]
        [MaxLength(50)]
        public string DX0001_ID { get; set; } = Guid.NewGuid().ToString();

        public string A0028_ID { get; set; }
        public string A0002_ID { get; set; }
        public string hoVaTen { get; set; }
        public string A0016_ID { get; set; }
        public string A0022_ID { get; set; }
        public string A0032_ID { get; set; }
        public string maForm { get; set; }
        public Nullable<int> trangThai { get; set; }
        public string ngayTao { get; set; }
        public string noiDungCongViec { get; set; }
        public Nullable<bool> daXoa { get; set; }
        public Nullable<int> tinhtrang { get; set; }
        public string T001C { get; set; }
        public string T002C { get; set; }
        public string T003C { get; set; }
        public string T004C { get; set; }
        public string T005C { get; set; }
        public string T006C { get; set; }
        public string T007C { get; set; }
        public string T008C { get; set; }
        public string T009C { get; set; }
        public string T010C { get; set; }
        public string T011C { get; set; }
        public string T012C { get; set; }
        public string T013C { get; set; }
        public string T014C { get; set; }
        public string T015C { get; set; }
        public string T016C { get; set; }
        public string T017C { get; set; }
        public string T018C { get; set; }
        public string T019C { get; set; }
        public string T020C { get; set; }
        public string T021C { get; set; }
        public string T022C { get; set; }
        public string T023C { get; set; }
        public string T024C { get; set; }
        public string T025C { get; set; }
        public string T026C { get; set; }
        public string T027C { get; set; }
        public string T028C { get; set; }
        public string T029C { get; set; }
        public string T030C { get; set; }
        public string T097C { get; set; }
        public string T098C { get; set; }
        public string T099C { get; set; }
        public string T100C { get; set; }

        public string DX0011_ID { get; set; }
        public string DX0010_ID { get; set; }
        public string DX0070_ID { get; set; }
        public virtual DX0011 DX0011 { get; set; }
        public virtual DX0010 DX0010 { get; set; }
        public virtual DX0070 DX0070 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "Thẻ taxi"
    /// </summary>
    [Table("DX0050")]
    public class DX0050
    {
        [Key]
        [MaxLength(50)]
        public string DX0050_ID { get; set; } = Guid.NewGuid().ToString();
        public string maThe { get; set; }
        public string soThe { get; set; }
        public string loaiThe { get; set; }
        public string hangTaxi { get; set; }
        public Nullable<DateTime> ngayPhatHanh { get; set; }
        public Nullable<DateTime> ngayHetHan { get; set; }
        public string ghiChu { get; set; }
        public Nullable<bool> trangThai { get; set; }
        public virtual ICollection <DX0060> DX0060 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "Sử dụng xe taxi"
    /// </summary>
    [Table("DX0060")]
    public class DX0060
    {
        [Key]
        [MaxLength(50)]
        public string DX0060_ID { get; set; } = Guid.NewGuid().ToString();
        public string DX0050_ID { get; set; }
        public string DX0070_ID { get; set; }
        public Nullable<DateTime> thoiGian { get; set; }
        public Nullable<bool> trangThai { get; set; }
        public string ghiChu { get; set; }
        public virtual DX0050 DX0050 { get; set; }
        public virtual ICollection<DX0061> DX0061 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "Chi tiết sử dụng xe taxi"
    /// </summary>
    [Table("DX0061")]
    public class DX0061
    {
        [Key]
        [MaxLength(50)]
        public string DX0061_ID { get; set; } = Guid.NewGuid().ToString();
        public string DX0060_ID { get; set; }
        public string DX0001_ID { get; set; }
        public string ghiChu { get; set; }
        public virtual DX0060 DX0060 { get; set; }
        public virtual DX0001 DX0001 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "Khung giờ sử dụng"
    /// </summary>
    [Table("DX0070")]
    public class DX0070
    {
        [Key]
        [MaxLength(50)]
        public string DX0070_ID { get; set; } = Guid.NewGuid().ToString();
        public string tenKhungGio { get; set; }
        public Nullable<TimeSpan> timeMin { get; set; }
        public Nullable<TimeSpan> timeMax { get; set; }
        public string ghiChu { get; set; }
        public Nullable<bool> trangThai { get; set; }
        public virtual ICollection<DX0001> DX0001 { get; set; }
    }
    /// <summary>
    /// Đây là bảng "thông báo"
    /// </summary>
    [Table("DX0100")]
    public class DX0100
    {
        [Key]
        [MaxLength(50)]
        public string DX0100_ID { get; set; } = Guid.NewGuid().ToString();
        public string tenKhungGio { get; set; }
    }
}