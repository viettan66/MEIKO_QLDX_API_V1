using QLDX_API_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLDX_API_V1.Controllers
{
    [RoutePrefix("api/DX0012")]
    public class DX0012Controller : ApiController
    {

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage getall()
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                var data = db.DX0012.AsEnumerable().Select(p => new
                {
                    p.DX0012_ID,
                    p.ghiChu,
                    p.bienSoXe,
                    p.DX0010_ID,
                    p.mobile,
                    p.soLuongGhe,
                    p.tenLaiXe,
                    p.trangThai,
                    DX0010=p.DX0010==null?null: new {p.DX0010.bienSoXe,
                        p.DX0010.DX0010_ID,
                        p.DX0010.ghiChu,
                        p.DX0010.maTuyenXe,
                        p.DX0010.mobile,
                        p.DX0010.tenLaiXe,
                        p.DX0010.tenTuyenXe,
                        p.DX0010.thuTu,
                        p.DX0010.trangThai,
                        p.DX0010.type
                    } 
                });
                return REST.GetHttpResponseMessFromObject(data);
            }
        }

        [Route("delete")]
        [HttpPost]
        public HttpResponseMessage delete([FromBody]DX0012[] values)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                results<object> list = new results<object>();
                values.ToList().ForEach(val => {
                    result<object> rel = new result<object>();
                    var check = db.DX0012.SingleOrDefault(p => p.DX0012_ID == val.DX0012_ID);
                    if (check != null)
                    {
                        db.DX0012.Remove(check);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", getDX0012(val));

                        }
                        catch (Exception d)
                        {
                            rel.set("ERR", val, d.Message);
                        }
                    }
                    else
                    {
                        rel.set("NOT_EXIST", getDX0012(val));
                    }
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]DX0012[] values)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                results<object> list = new results<object>();
                values.ToList().ForEach(val => {
                    result<object> rel = new result<object>();
                    var check = db.DX0012.SingleOrDefault(p => p.DX0012_ID == val.DX0012_ID);
                    if (check == null)
                    {
                        db.DX0012.Add(val);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", getDX0012(val));

                        }
                        catch (Exception d)
                        {
                            rel.set("ERR", val, d.Message);
                        }
                    }
                    else
                    {
                        check.ghiChu=val.ghiChu   ;
                    check.bienSoXe=val.bienSoXe   ;
                    check.DX0010_ID=val.DX0010_ID   ;
                    check.mobile=val.mobile   ;
                    check.soLuongGhe=val.soLuongGhe   ;
                    check.tenLaiXe=val.tenLaiXe   ;
                    check.trangThai=val.trangThai   ;
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", getDX0012(check));

                        }
                        catch (Exception d)
                        {
                            rel.set("ERR", getDX0012(check), d.Message);
                        }
                    }
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }
        public object getDX0012(DX0012 p)
        {
            return new
            {
                p.DX0012_ID,
                p.ghiChu,
                p.bienSoXe,
                p.DX0010_ID,
                p.mobile,
                p.soLuongGhe,
                p.tenLaiXe,
                p.trangThai,
                DX0010 = p.DX0010 == null ? null : new
                {
                    p.DX0010.bienSoXe,
                    p.DX0010.DX0010_ID,
                    p.DX0010.ghiChu,
                    p.DX0010.maTuyenXe,
                    p.DX0010.mobile,
                    p.DX0010.tenLaiXe,
                    p.DX0010.tenTuyenXe,
                    p.DX0010.thuTu,
                    p.DX0010.trangThai,
                    p.DX0010.type
                }

            };
        }
    }
}
