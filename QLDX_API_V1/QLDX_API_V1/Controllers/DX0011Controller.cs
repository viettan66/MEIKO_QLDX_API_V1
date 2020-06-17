using QLDX_API_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLDX_API_V1.Controllers
{
    [RoutePrefix("api/DX0011")]
    public class DX0011Controller : ApiController
    {
        [Route("getall/{id}")]
        [HttpGet]
        public HttpResponseMessage getall(string id)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                var data = db.DX0011.Where(p => id == "all" ? true : (p.DX0011_ID == id)).OrderBy(t=>t.tenDiemDon).Select(p => new
                {
                    p.DX0011_ID,
                    p.DX0013_ID,
                    p.DX0014_ID,
                    p.maDiemDon,
                    p.tenDiemDon,
                    p.ghiChu,
                    p.trangThai,
                    p.taxi,
                    p.gioDon,
                    p.thuTu,
                    p.lat,
                    p.lng,
                    DX0010D = p.DX0010D.Select(o => new
                    {
                        o.DX0010_ID,
                        o.DX0011_ID,
                        DX0010 = new { o.DX0010.bienSoXe, o.DX0010.DX0010_ID, o.DX0010.ghiChu, o.DX0010.maTuyenXe, o.DX0010.mobile, o.DX0010.tenLaiXe, o.DX0010.tenTuyenXe, o.DX0010.thuTu, o.DX0010.trangThai }
                    }),
                    DX0014 = new {p.DX0014.DX0014_ID,p.DX0014.tenDiaDanh}
                });
                return REST.GetHttpResponseMessFromObject(data);
            }
        }
        [Route("Update")]
        [HttpPost]
        public HttpResponseMessage Update([FromBody]DX0011[] values)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                results<object> list = new results<object>();
                values.ToList().ForEach(val =>
                {
                    result<object> rel = new result<object>();
                    var check = db.DX0011.SingleOrDefault(p => p.DX0011_ID == val.DX0011_ID);
                    if (check != null)
                    {
                        check.DX0013_ID = val.DX0013_ID;
                        check.DX0014_ID = val.DX0014_ID;
                        check.ghiChu = val.ghiChu;
                        check.lat = val.lat;
                        check.lng = val.lng;
                        check.gioDon = val.gioDon;
                        check.maDiemDon = val.maDiemDon;
                        check.taxi = val.taxi;
                        check.tenDiemDon = val.tenDiemDon;
                        check.thuTu = val.thuTu;
                        check.trangThai = val.trangThai;
                        try
                        {
                            db.SaveChanges();
                            rel.set("UPDATE", getDX0011(check));
                        }
                        catch (Exception s)
                        {
                            rel.set("ERR", null, s.Message);
                        }

                    }
                    else
                    {
                        db.DX0011.Add(val);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", getDX0011(val));
                        }
                        catch (Exception s)
                        {
                            rel.set("ERR", null, s.Message);
                        }
                    }
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }
        [Route("Delete")]
        [HttpPost]
        public HttpResponseMessage Delete([FromBody]DX0011 val)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                result<object> rel = new result<object>();
                var check = db.DX0011.SingleOrDefault(p => p.DX0011_ID == val.DX0011_ID);
                if (check != null)
                {
                    db.DX0011.Remove(check);
                    try
                    {
                        db.SaveChanges();
                        rel.set("OK", null);
                    }
                    catch (Exception s)
                    {
                        rel.set("ERR", null, s.Message);
                    }
                }
                return rel.ToHttpResponseMessage();
            }
        }
        [Route("Deletes")]
        [HttpPost]
        public HttpResponseMessage Deletes([FromBody]DX0011[] values)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                results<object> list = new results<object>();
                values.ToList().ForEach(val =>
                {
                    result<object> rel = new result<object>();
                    var check = db.DX0011.SingleOrDefault(p => p.DX0011_ID == val.DX0011_ID);
                    if (check != null)
                    {
                        db.DX0011.Remove(check);
                        try
                        {
                            db.SaveChanges();
                            rel.set("DELETE", getDX0011(check));
                        }
                        catch (Exception s)
                        {
                            rel.set("ERR", getDX0011(check), s.Message);
                        }
                    }
                    list.add(rel);
                });
                
                return list.ToHttpResponseMessage();
            }
        }
        public object getDX0011(DX0011 p)
        {
            return new
            {
                p.DX0011_ID,
                p.DX0013_ID,
                p.DX0014_ID,
                p.ghiChu,
                p.lat,
                p.gioDon,
                p.lng,
                p.maDiemDon,
                p.taxi,
                p.tenDiemDon,
                p.thuTu,
                p.trangThai
            };
        }
        [Route("getalldiemdonduocditaxi/{DX0070_id}")]
        [HttpGet]
        public HttpResponseMessage getalldiemdonduocditaxi(string DX0070_id)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                // var data = db.Database.SqlQuery<DX0011>("select * from dx0011 as G where DX0013_ID in (select dx0013_id from dx0013) order by DX0013_ID");
                var data = db.DX0011.AsEnumerable().Where(p => db.DX0013.Select(f => f.DX0013_ID).Contains(p.DX0013_ID)).Select(p => new
                {
                    p.DX0011_ID,
                    p.DX0013_ID,
                    p.DX0014_ID,
                    p.maDiemDon,
                    p.tenDiemDon,
                    p.ghiChu,
                    p.gioDon,
                    p.trangThai,
                    p.taxi,
                    p.thuTu,
                    p.lat,
                    p.lng,
                    DX0013 = db.DX0013.AsEnumerable().Where(f => f.trangThai == true).OrderBy(f => f.DX0013_ID).Select(f => new
                    {
                        f.DX0011_ID,
                        f.DX0013_ID,
                        f.ghiChu,
                        f.lat,
                        f.lng,
                        f.maDiemTaxi,
                        f.tenDiemTaxi,
                        f.trangThai,
                        count = p.DX0013_ID == f.DX0013_ID? db.Database.SqlQuery<DX0001>("select * from dx0001 as G where maForm='SF015' and T007C='"+DX0070_id+ "' and T002C in (select  manhansu from dx0020 where DX0011_ID='"+p.DX0011_ID+ "') and ngayTao>=CONVERT(date,getdate(),23)") : null
                    })
                }); ;
                return REST.GetHttpResponseMessFromObject(data);
            }
        }

    }
}
