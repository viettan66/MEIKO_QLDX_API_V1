using QLDX_API_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLDX_API_V1.Controllers
{
    [RoutePrefix("api/DX0010D")]
    public class DX0010DController : ApiController
    {
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]DX0010D[] values)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                results<object> list = new results<object>();
                values.ToList().ForEach(val =>
                {
                    result<object> rel = new result<object>();
                    var check = db.DX0010D.Where(p => p.DX0010_ID == val.DX0010_ID && p.DX0011_ID == val.DX0011_ID).FirstOrDefault();
                    if (check == null)
                    {
                        var l = new DX0010D() { thuTu = val.thuTu, DX0010_ID = val.DX0010_ID, DX0011_ID = val.DX0011_ID, ghiChu = val.ghiChu };
                        db.DX0010D.Add(l );
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", getDX0010D(val));
                        }
                        catch (Exception f)
                        {
                            rel.set("ERR", getDX0010D(val), f.Message);
                        }
                    }
                    else
                    {
                        check.thuTu = val.thuTu;
                        try
                        {
                            db.SaveChanges();
                            rel.set("UPDATE", getDX0010D(val));
                        }
                        catch (Exception f)
                        {
                            rel.set("ERR", getDX0010D(val), f.Message);
                        }
                    }
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }
        [Route("delete")]
        [HttpPost]
        public HttpResponseMessage delete([FromBody]DX0010D val)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                    result<object> rel = new result<object>();
                    var check = db.DX0010D.Where(p => p.DX0010_ID == val.DX0010_ID && p.DX0011_ID == val.DX0011_ID).FirstOrDefault();
                    if (check != null)
                    {
                        db.DX0010D.Remove(check);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", getDX0010D(val));
                        }
                        catch (Exception f)
                        {
                            rel.set("ERR", getDX0010D(val), f.Message);
                        }
                    }
                return rel.ToHttpResponseMessage();
            }
        }
        public object getDX0010D(DX0010D p)
        {
            using(var db=new QLDX_DB())
            {

            return new
            {
                p.DX0010D_ID,
                p.DX0010_ID,
                p.DX0011_ID,
                p.ghiChu,
                p.thuTu,
                DX0010 = db.DX0010.Where(x=>x.DX0010_ID==p.DX0010_ID).Select(x=> new
                {
                    x.bienSoXe,
                    x.DX0010_ID,
                    x.ghiChu,
                    x.maTuyenXe,
                    x.mobile,
                    x.tenLaiXe,
                    x.tenTuyenXe,
                    x.thuTu,
                    x.trangThai,
                    x.type,
                }).FirstOrDefault(),
                DX0011 = db.DX0011.Where(x => x.DX0011_ID == p.DX0011_ID).Select(x => new
                {
                    x.DX0011_ID,
                    x.DX0013_ID,
                    x.DX0014_ID,
                    x.ghiChu,
                    x.lat,
                    x.lng,
                    x.maDiemDon,
                    x.taxi,
                    x.tenDiemDon,
                    x.thuTu,
                    x.trangThai,
                }).FirstOrDefault(),
            };
            }
        }
    }
}
