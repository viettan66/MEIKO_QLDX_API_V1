using QLDX_API_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLDX_API_V1.Controllers
{
    [RoutePrefix("api/DX0013")]
    public class DX0013Controller : ApiController
    {
        [Route("getall/{id}")]
        [HttpGet]
        public HttpResponseMessage getall(string id)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                var data = db.Database.SqlQuery<DX0013>(@"select  * from DX0013  where trangthai=1" + (id != "all" ? " and DX0013_ID='" + id + "'" : "")+" order by DX0013_ID");
                return REST.GetHttpResponseMessFromObject(data);
            }
        }
        [Route("getdx0011/{id}")]
        [HttpGet]
        public HttpResponseMessage getdx0011(string id)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                var data = db.Database.SqlQuery<DX0011>(@"select  * from DX0011 where DX0013_ID='" + id + "'");
                return REST.GetHttpResponseMessFromObject(data);
            }
        }
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]DX0013[] values)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                results<object> list = new results<object>();
                values.ToList().ForEach(val =>
                {
                    result<object> rel = new result<object>();
                    var check = db.DX0013.SingleOrDefault(p => p.DX0013_ID == val.DX0013_ID);
                    if(check==null)
                    {
                        db.DX0013.Add(val);
                        try
                        {
                            db.SaveChanges();

                            rel.set("OK", getDX0013(val), "Thành công.");
                        }
                        catch (Exception f)
                        {

                            rel.set("ERR", getDX0013(val), "Thất bại: ");
                        }
                    }
                    else
                    {
                        check.ghiChu = val.ghiChu;
                        check.lat = val.lat   ;
                        check.lng = val.lng   ;
                        check.maDiemTaxi = val.maDiemTaxi   ;
                        check.tenDiemTaxi = val.tenDiemTaxi   ;
                        check.trangThai = val.trangThai   ;

                        try
                        {
                            db.SaveChanges();

                            rel.set("UPDATE", getDX0013(check), "Thành công.");
                        }
                        catch (Exception f)
                        {

                            rel.set("ERR", getDX0013(val), "Thất bại: ");
                        }
                    }
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }

        }  
        public object getDX0013(DX0013 p)
        {
            return new
            {
                p.DX0011_ID,
                p.DX0013_ID,
                p.ghiChu,
                p.lat,
                p.lng,
                p.maDiemTaxi,
                p.tenDiemTaxi,
                p.trangThai,
                DX0011 = p.DX0011==null? null:p.DX0011.Select(g => new
                {
                    g.DX0011_ID,
                    g.DX0013_ID,
                    g.DX0014_ID,
                    g.ghiChu,
                    g.lat,
                    g.lng,
                    g.maDiemDon,
                    g.taxi,
                    g.tenDiemDon,
                    g.thuTu,
                    g.trangThai
                })
            };
        }
        [Route("delete")]
        [HttpPost]
        public HttpResponseMessage delete([FromBody]DX0013[] values)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                results<object> list = new results<object>();
                values.ToList().ForEach(val => {
                    result<object> rel = new result<object>();
                    var check = db.DX0013.SingleOrDefault(p => p.DX0013_ID == val.DX0013_ID);
                    if (check != null)
                    {
                        db.DX0013.Remove(check);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", getDX0013(val));

                        }
                        catch (Exception d)
                        {
                            rel.set("ERR", val, d.Message);
                        }
                    }
                    else
                    {
                        rel.set("NOT_EXIST", getDX0013(val));
                    }
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }
    }
}
