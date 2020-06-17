using QLDX_API_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLDX_API_V1.Controllers
{
    [RoutePrefix("api/DX0020")]
    public class DX0020Controller : ApiController
    {
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage getall_tuyenduong()
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                var data = db.DX0020.Select(p => new
                {
                    p.ban_id,
                    p.capbac,
                    p.chucvu,
                    p.cmtnd_so,
                    p.diachitamtru,
                    p.diachithuongtru,
                    p.dienthoai_didong,
                    p.DX0010_ID,
                    p.DX0011_ID,
                    p.DX0020_ID,
                    p.email,
                    p.gioitinh,
                    p.hodem,
                    p.manhansu,
                    p.ngaysinh,
                    p.phong_id,
                    p.ten,
                    p.thetu_id,
                    p.thoiGianSuDung,
                    p.trangThai,
                    DX0010=new {p.DX0010.bienSoXe,
                        p.DX0010.DX0010_ID,
                        p.DX0010.ghiChu,
                        p.DX0010.maTuyenXe,
                        p.DX0010.mobile,
                        p.DX0010.tenLaiXe,
                        p.DX0010.tenTuyenXe,
                        p.DX0010.thuTu,
                        p.DX0010.trangThai,
                        p.DX0010.type,
                    },
                    DX0011 = new
                    {
                        p.DX0011.DX0011_ID,
                        p.DX0011.DX0013_ID,
                        p.DX0011.DX0014_ID,
                        p.DX0011.ghiChu,
                        p.DX0011.lat,
                        p.DX0011.lng,
                        p.DX0011.maDiemDon,
                        p.DX0011.taxi,
                        p.DX0011.tenDiemDon,
                        p.DX0011.thuTu,
                        p.DX0011.trangThai
                    },
                });
                return REST.GetHttpResponseMessFromObject(data);
            }
        }
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]DX0001[] values)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                results<object> list = new results<object>();
                values.ToList().ForEach(val =>
                {
                    result<object> rel = new result<object>();
                    var data = db.Database.SqlQuery<DX0020>("select * from DX0020 where manhansu='"+val.T002C+"'").FirstOrDefault();
                    if (data == null)
                    {
                        var kl = new DX0020()
                        {
                            ban_id = val.T098C,
                            capbac = val.T005C,
                            dienthoai_didong = val.T004C,
                            DX0011_ID = val.T008C,
                            DX0010_ID = val.T009C,
                            hodem = val.T001C,
                            manhansu = val.T002C,
                            trangThai = 1,
                            phong_id = val.T098C,
                            thoiGianSuDung = val.T010C,

                        };
                        db.DX0020.Add(kl);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK",val , "Thành công.");
                        }
                        catch (Exception g)
                        {

                            rel.set("ERR", val, "Thất bại: ");
                        }
                    }
                    else
                    {
                        rel.set("EXIST", val, "Đã tồn tại.");
                    }
                    list.add(rel);
                });

                return list.ToHttpResponseMessage(); ;
            }
        }

        [Route("delete")]
        [HttpPost]
        public HttpResponseMessage delete([FromBody]DX0020[] values)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                results<object> list = new results<object>();
                values.ToList().ForEach(val =>
                {
                    result<object> rel = new result<object>();
                    var check = db.DX0020.SingleOrDefault(p => p.DX0020_ID == val.DX0020_ID);
                    if (check != null)
                    {
                        try
                        {
                            db.DX0020.Remove(check);
                            db.SaveChanges();
                            rel.set("DELETE", getDX0020(val));
                        }
                        catch (Exception ee)
                        {
                            rel.set("ERR", getDX0020(val), ee.Message);
                        }
                    }
                    else
                    {
                        rel.set("NOT_EXIST", getDX0020(val));
                    }
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }
        [Route("getdiembus/{id}")]
        [HttpGet]
        public HttpResponseMessage getdiembus(string id)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                var check = db.Database.SqlQuery<DX0011>("select  * from dx0011 where dx0011_ID=(select top(1) dx0011_id from dx0020 where manhansu='" + id + "')").FirstOrDefault();
                return REST.GetHttpResponseMessFromObject(check);
            }
        }
        [Route("gettuyenbus/{id}")]
        [HttpGet]
        public HttpResponseMessage gettuyenbus(string id)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                var check = db.Database.SqlQuery<DX0010>("select top(1) * from dx0010 where type=3 and dx0010_ID in (select dx0010_id from dx0010d where dx0011_id= (select top(1)  dx0011_id from dx0011 where dx0011_ID=(select top(1) dx0011_id from dx0020 where manhansu='" + id + "')))").FirstOrDefault();
                return REST.GetHttpResponseMessFromObject(check);
            }
        }
        [Route("kiemtradangkyxebus/{manhansu}")]
        [HttpGet]
        public HttpResponseMessage kiemtradangkyxebus(string manhansu)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                var check = db.Database.SqlQuery<DX0020>(@"
                    select * from dx0020 where manhansu='"+manhansu+@"'
                    ").FirstOrDefault();
                if (check == null)
                {
                    return REST.GetHttpResponseMessFromObject(new { value = false, messager = "Bạn chưa đăng ký sử dụng xe bus hằng ngày nên chưa thể yêu cầu sử dụng xe taxi." });
                }
                else
                {
                    var check2 = db.Database.SqlQuery<DX0010>(@"
                    select top(1) * from dx0010 where type=3 and dx0010_ID in (
                    select dx0010_id from dx0010d where dx0011_id= (select top(1) 
                    dx0011_id from dx0011 where dx0011_ID=(select top(1) dx0011_id from dx0020 where manhansu='" + manhansu + @"')))
                    ").FirstOrDefault();
                    if (check2 == null)
                    {
                        return REST.GetHttpResponseMessFromObject(new { value = false, messager = "Tuyến xe bus bạn đăng ký đi làm hằng ngày chưa hỗ trợ sử dụng taxi khi làm thêm giờ." });
                    }
                    else
                    {
                        return REST.GetHttpResponseMessFromObject(new { value = true, messager = "" });
                    }
                }
                return REST.GetHttpResponseMessFromObject(check);
            }
        }
        public object getDX0020(DX0020 p)
        {
            return new
            {
                p.ban_id,
                p.capbac,
                p.chucvu,
                p.cmtnd_so,
                p.diachitamtru,
                p.diachithuongtru,
                p.dienthoai_didong,
                p.DX0011_ID,
                p.DX0020_ID,
                p.email,
                p.gioitinh,
                p.hodem,
                p.manhansu,
                p.ngaysinh,
                p.phong_id,
                p.ten,
                p.thetu_id,
                p.trangThai
            }
            ;
        }
    }
}
