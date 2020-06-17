using QLDX_API_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLDX_API_V1.Controllers
{
    [RoutePrefix("api/DX0050")]
    public class DX0050Controller : ApiController
    {
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage getall()
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                var data = db.DX0050.AsEnumerable().Select(p => new
                {
                    p.DX0050_ID,
                    p.ghiChu,
                    p.hangTaxi,
                    p.loaiThe,
                    p.maThe,
                    p.ngayHetHan,
                    p.ngayPhatHanh,
                    p.soThe,
                    p.trangThai,
                    DX0060 = p.DX0060.Select(k => new
                    {
                        k.DX0050_ID,
                        k.DX0060_ID,
                        k.ghiChu,
                        k.thoiGian,
                        DX0061= k.DX0061.Select(f=>new {
                            f.DX0001_ID,
                            f.DX0060_ID,
                            f.DX0061_ID,
                            f.ghiChu
                        })
                    })
                });
                return REST.GetHttpResponseMessFromObject(data);
            }
        }

        [Route("delete")]
        [HttpPost]
        public HttpResponseMessage delete([FromBody]DX0050[] values)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                results<object> list = new results<object>();
                values.ToList().ForEach(val => {
                    result<object> rel = new result<object>();
                    var check = db.DX0050.SingleOrDefault(p => p.DX0050_ID == val.DX0050_ID);
                    if (check != null)
                    {
                        db.DX0050.Remove(check);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", getDX0050(val));

                        }
                        catch (Exception d)
                        {
                            rel.set("ERR", val, d.Message);
                        }
                    }
                    else
                    {
                        rel.set("NOT_EXIST", getDX0050(val));
                    }
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]DX0050[] values)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                results<object> list = new results<object>();
                values.ToList().ForEach(val => {
                    result<object> rel = new result<object>();
                    var check = db.DX0050.SingleOrDefault(p => p.DX0050_ID == val.DX0050_ID);
                    if (check == null)
                    {
                        db.DX0050.Add(val);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", getDX0050(val));

                        }
                        catch (Exception d)
                        {
                            rel.set("ERR", val, d.Message);
                        }
                    }
                    else
                    {
                        check.ghiChu = val.ghiChu;
                        check.hangTaxi = val.hangTaxi;
                        check.trangThai = val.trangThai;
                        check.loaiThe = val.loaiThe;
                        check.maThe = val.maThe;
                        check.ngayHetHan = val.ngayHetHan;
                        check.ngayPhatHanh = val.ngayPhatHanh;
                        check.soThe = val.soThe;
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", getDX0050(check));

                        }
                        catch (Exception d)
                        {
                            rel.set("ERR", getDX0050(check), d.Message);
                        }
                    }
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }
        public object getDX0050(DX0050 p)
        {
            return  new
            {
                p.DX0050_ID,
                p.ghiChu,
                p.hangTaxi,
                p.loaiThe,
                p.maThe,
                p.ngayHetHan,
                p.ngayPhatHanh,
                p.soThe,
                p.trangThai,
                DX0060 = p.DX0060==null?null:p.DX0060.Select(k => new
                {
                    k.DX0050_ID,
                    k.DX0060_ID,
                    k.ghiChu,
                    k.thoiGian,
                    DX0061 = k.DX0061 ==null?null:k.DX0061.Select(f => new {
                        f.DX0001_ID,
                        f.DX0060_ID,
                        f.DX0061_ID,
                        f.ghiChu
                    })
                })
            };
        }
    }
}
