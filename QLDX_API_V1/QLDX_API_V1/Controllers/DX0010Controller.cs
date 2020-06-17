using QLDX_API_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLDX_API_V1.Controllers
{

    [RoutePrefix("api/DX0010")]
    public class DX0010Controller : ApiController
    {
        [Route("getall_tuyenduong/{id}")]
        [HttpGet]
        public HttpResponseMessage getall_tuyenduong(string id)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
               
                var data = db.DX0010.Where(b =>b.trangThai==true&&b.type!=3&& db.DX0010D.Where(p => p.DX0011_ID == id).Select(p => p.DX0010_ID).Contains(b.DX0010_ID)).Select(p => new
                {
                    p.bienSoXe,
                    p.DX0010_ID,
                    p.ghiChu,
                    p.maTuyenXe,
                    p.mobile,
                    p.tenLaiXe,
                    p.tenTuyenXe,
                    p.thuTu,
                    p.trangThai,
                    p.type
                });
                return REST.GetHttpResponseMessFromObject(data);
            }
        }
        [Route("getall/{id}")]
        [HttpGet]
        public HttpResponseMessage getall(string id)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                var data = db.DX0010.AsEnumerable().Where(p => id == "all" ? true : (p.DX0010_ID == id)).Select(p => new
                {
                    p.DX0010_ID,
                    p.ghiChu,
                    p.maTuyenXe,
                    p.tenTuyenXe,
                    p.thuTu,
                    p.trangThai,
                    DX0010D = p.DX0010D.Select(o => new
                    {
                        o.DX0010_ID,
                        o.DX0011_ID,
                        o.thuTu,
                        DX0011 = new
                        {
                            o.DX0011.DX0011_ID,
                            o.DX0011.DX0013_ID,
                            o.DX0011.ghiChu,
                            o.DX0011.lat,
                            o.DX0011.lng,
                            o.DX0011.maDiemDon,
                            o.DX0011.taxi,
                            o.DX0011.tenDiemDon,
                            o.DX0011.thuTu,
                            o.DX0011.trangThai,
                            DX0020 = (o.DX0011.DX0020.Count == 0 ? null : o.DX0011.DX0020.Select(h => new
                            {
                                h.ban_id,
                                h.capbac,
                                h.chucvu,
                                h.cmtnd_so,
                                h.diachitamtru,
                                h.diachithuongtru,
                                h.dienthoai_didong,
                                h.DX0011_ID,
                                h.DX0020_ID,
                                h.email,
                                h.gioitinh,
                                h.hodem,
                                h.manhansu,
                                h.ngaysinh,
                                h.phong_id,
                                h.ten,
                                h.thetu_id,
                                h.trangThai
                            }))
                        }

                    }).OrderBy(f => f.thuTu)
                });
                return REST.GetHttpResponseMessFromObject(data);
            }
        }
      public struct filter
        {
            public Nullable<int> type { get; set; }
        }
        [Route("getalls")]
        [HttpPost]
        public HttpResponseMessage getalls([FromBody]filter filter)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                var data = db.DX0010.AsEnumerable().Select(p => new
                {
                    p.DX0010_ID,
                    p.ghiChu,
                    p.maTuyenXe,
                    p.tenTuyenXe,
                    p.thuTu,
                    p.type,
                    p.trangThai,
                    DX0010D = p.DX0010D.Select(o => new
                    {
                        o.DX0010_ID,
                        o.DX0011_ID,
                        o.thuTu,
                        DX0011 = new
                        {
                            o.DX0011.DX0011_ID,
                            o.DX0011.DX0013_ID,
                            o.DX0011.ghiChu,
                            o.DX0011.lat,
                            o.DX0011.lng,
                            o.DX0011.gioDon,
                            o.DX0011.maDiemDon,
                            o.DX0011.taxi,
                            o.DX0011.tenDiemDon,
                            o.DX0011.thuTu,
                            o.DX0011.trangThai,
                            DX0020 = (o.DX0011.DX0020.Count == 0 ? null : o.DX0011.DX0020.Select(h => new
                            {
                                h.ban_id,
                                h.capbac,
                                h.chucvu,
                                h.cmtnd_so,
                                h.diachitamtru,
                                h.diachithuongtru,
                                h.dienthoai_didong,
                                h.DX0011_ID,
                                h.DX0020_ID,
                                h.email,
                                h.gioitinh,
                                h.hodem,
                                h.manhansu,
                                h.ngaysinh,
                                h.phong_id,
                                h.ten,
                                h.thetu_id,
                                h.trangThai
                            })),
                            DX0014=o.DX0011.DX0014==null?null:new { o.DX0011.DX0014.tenDiaDanh },
                          
                        } 

                    }).OrderBy(f => f.thuTu),
                    DX0012 = p.DX0012 == null ? null : p.DX0012.Select(k => new
                    {
                        k.DX0012_ID,
                        k.ghiChu,
                        k.bienSoXe,
                        k.DX0010_ID,
                        k.mobile,
                        k.soLuongGhe,
                        k.tenLaiXe,
                        k.trangThai,
                    })
                });
                if (filter.type != null)
                {
                    data = data.Where(p => p.type == filter.type);
                }
                return REST.GetHttpResponseMessFromObject(data);
            }
        }
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]DX0010[] values)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                results<object> list = new results<object>();
                values.ToList().ForEach(val =>
                {
                    result<object> rel = new result<object>();
                    var check = db.DX0010.SingleOrDefault(p => p.DX0010_ID == val.DX0010_ID);
                    if (check != null)
                    {
                        check.ghiChu = val.ghiChu;
                        check.maTuyenXe = val.maTuyenXe;
                        check.tenTuyenXe = val.tenTuyenXe;
                        check.thuTu = val.thuTu;
                        check.trangThai = val.trangThai;
                        check.type = val.type;
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", getDX0010(check));
                        }
                        catch (Exception ee)
                        {
                            rel.set("ERR", getDX0010(val), ee.Message);
                        }
                    }
                    else
                    {
                        db.DX0010.Add(val);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", getDX0010(val));
                        }
                        catch (Exception ee)
                        {
                            rel.set("ERR", getDX0010(val), ee.Message);
                        }
                    }
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }
        [Route("delete")]
        [HttpPost]
        public HttpResponseMessage delete([FromBody]DX0010[] values)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                results<object> list = new results<object>();
                values.ToList().ForEach(val =>
                {
                    result<object> rel = new result<object>();
                    var check = db.DX0010.SingleOrDefault(p => p.DX0010_ID == val.DX0010_ID);
                    if (check != null)
                    {
                        try
                        {
                            db.DX0010D.RemoveRange(check.DX0010D);
                            db.DX0010.Remove(check);
                            db.SaveChanges();
                            rel.set("OK", getDX0010(val));
                        }
                        catch (Exception ee)
                        {
                            rel.set("ERR", getDX0010(val), ee.Message);
                        }
                    }
                    else
                    {
                        rel.set("NOT_EXIST", getDX0010(val));
                    }
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }
        public object getDX0010(DX0010 value)
        {
            return new
            {
                bienSoXe = value.bienSoXe,
                DX0010_ID = value.DX0010_ID,
                ghiChu = value.ghiChu,
                maTuyenXe = value.maTuyenXe,
                mobile = value.mobile,
                tenLaiXe = value.tenLaiXe,
                tenTuyenXe = value.tenTuyenXe,
                thuTu = value.thuTu,
                trangThai = value.trangThai,
                type = value.type,
                //DX0001 = value.DX0001 != null ? value.DX0001.Select(f => new
                //{
                //    f.boPhan,
                //    f.capBac,
                //    f.diDong,
                //    f.DX0001_ID,
                //    f.DX0010_ID,
                //    f.DX0011_ID,
                //    f.DX0070_ID,
                //    f.ghiChu,
                //    f.hoTen,
                //    f.lyDoThayDoi,
                //    f.maNhanSu,
                //    f.mayLe,
                //    f.thoiGianBatDauSuDung,
                //    f.trangThai
                //}) : null,
                DX0010D = value.DX0010D != null ? value.DX0010D.Select(f => new
                {
                    f.DX0010D_ID,
                    f.DX0010_ID,
                    f.DX0011_ID,
                    f.ghiChu,
                    f.thuTu
                }) : null

            };
        }

    }
}
