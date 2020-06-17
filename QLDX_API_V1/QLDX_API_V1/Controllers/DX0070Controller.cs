using QLDX_API_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLDX_API_V1.Controllers
{
    [RoutePrefix("api/DX0070")]
    public class DX0070Controller : ApiController
    {
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]DX0070[] values)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                results<object> list = new results<object>();
                values.ToList().ForEach(val => {
                    result<object> rel = new result<object>();
                    var check = db.DX0070.SingleOrDefault(p => p.DX0070_ID == val.DX0070_ID);
                    if (check == null)
                    {
                        db.DX0070.Add(val);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", getDX0070(val));

                        }
                        catch (Exception d)
                        {
                            rel.set("ERR", val, d.Message);
                        }
                    }
                    else
                    {
                        check.ghiChu = val.ghiChu;
                        check.timeMin = val.timeMin;
                        check.timeMax = val.timeMax;
                        check.tenKhungGio = val.tenKhungGio;
                        check.trangThai = val.trangThai;
                        try
                        {
                            db.SaveChanges();
                            rel.set("UPDATE", getDX0070(check));
                        }
                        catch (Exception d)
                        {
                            rel.set("ERR", getDX0070(check), d.Message);
                        }
                    }
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }

        [Route("delete")]
        [HttpPost]
        public HttpResponseMessage delete([FromBody]DX0070[] values)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                results<object> list = new results<object>();
                values.ToList().ForEach(val => {
                    result<object> rel = new result<object>();
                    var check = db.DX0070.SingleOrDefault(p => p.DX0070_ID == val.DX0070_ID);
                    if (check != null)
                    {
                        db.DX0070.Remove(check);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", getDX0070(val));

                        }
                        catch (Exception d)
                        {
                            rel.set("ERR", val, d.Message);
                        }
                    }
                    else
                    {
                        rel.set("NOT_EXIST", val);
                    }
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }
        [Route("getall/{id}")]
        [HttpGet]
        public HttpResponseMessage getall(string id)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                var data = db.DX0070.AsEnumerable().Where(p => id == "all" ? true : (p.DX0070_ID == id)).Select(p => new
                {
                    p.DX0070_ID,
                    p.ghiChu,
                    p.tenKhungGio,
                    p.timeMax,
                    p.timeMin,
                    p.trangThai
                });
                return REST.GetHttpResponseMessFromObject(data);
            }
        }

        public object getDX0070(DX0070 val)
        {
            return new
            {
                val.DX0070_ID,
                val.ghiChu,
                val.tenKhungGio,
                val.trangThai,
                val.timeMin,
                val.timeMax,
                //DX0001 = val.DX0001 == null ? null : val.DX0001.Select(p => new
                //{
                //    p.DX0011_ID,
                //    p.DX0013_ID,
                //    p.DX0014_ID,
                //    p.ghiChu,
                //    p.lat,
                //    p.lng,
                //    p.maDiemDon,
                //    p.taxi,
                //    p.tenDiemDon,
                //    p.thuTu,
                //    p.trangThai
                //})
            };
        }
    }
}
