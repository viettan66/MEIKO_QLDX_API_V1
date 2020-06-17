using QLDX_API_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLDX_API_V1.Controllers
{
    [RoutePrefix("api/DX0060")]
    public class DX0060Controller : ApiController
    {
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]DX0060[] values)
        {
            //return REST.GetHttpResponseMessFromObject(values);
            results<object> list = new results<object>();
            using (QLDX_DB db = new QLDX_DB())
            {
                values.ToList().ForEach(val =>
                {
                   result <object> rel = new result<object>();
                    var check = db.DX0060.SingleOrDefault(p => p.DX0060_ID==val.DX0060_ID);
                    if(check==null)
                    {
                        val.thoiGian = DateTime.Now;
                        val.trangThai = false;
                        db.DX0060.Add(val);
                        try
                        {
                            db.SaveChanges();
                            val.DX0061.ToList().ForEach(v=> {
                                var don = db.DX0001.SingleOrDefault(b=>b.DX0001_ID==v.DX0001_ID);
                                if (don != null)
                                {
                                    don.trangThai = 3;

                                }
                            });
                            db.SaveChanges();
                            rel.set("OK", getDX00600(val), "Thành công.");
                        }
                        catch (Exception)
                        {
                            rel.set("ERR", getDX00600(val), "Thất bại: ");
                        }
                    }
                    else
                    {

                    }
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }
        public struct filter { }
        
        [Route("getall")]
        [HttpPost]
        public HttpResponseMessage getall([FromBody]filter filter)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                var data = db.DX0060.AsEnumerable().Select(p=>getDX00600(p));
                    return REST.GetHttpResponseMessFromObject(data);
            }
        }
        public object getDX00600 (DX0060 p)
        {
            using(var db=new QLDX_DB())
            { 
            return new
            {
                p.DX0050_ID,
                p.DX0060_ID,
                p.DX0070_ID,
                p.ghiChu,
                p.thoiGian,
                p.trangThai,
                DX0070=db.DX0070.Where(f=>f.DX0070_ID==p.DX0070_ID).Select(f=>new {
                f.tenKhungGio}).FirstOrDefault(),
                DX0061 = p.DX0061 == null ? null : p.DX0061.Select(f => new
                {
                    f.DX0001_ID,
                    f.DX0060_ID,
                    f.DX0061_ID,
                    f.ghiChu,
                    DX0001 = f.DX0001 == null ? null : new
                    {
                        f.DX0001.DX0001_ID,
                        f.DX0001.A0028_ID,
                        f.DX0001.A0002_ID,
                        f.DX0001.hoVaTen,
                        f.DX0001.A0016_ID,
                        f.DX0001.A0022_ID,
                        f.DX0001.A0032_ID,
                        f.DX0001.maForm,
                        f.DX0001.trangThai,
                        f.DX0001.ngayTao,
                        f.DX0001.noiDungCongViec,
                        f.DX0001.daXoa,
                        f.DX0001.tinhtrang,
                        f.DX0001.T001C,
                        f.DX0001.T002C,
                        f.DX0001.T003C,
                        f.DX0001.T004C,
                        f.DX0001.T005C,
                        f.DX0001.T006C,
                        f.DX0001.T007C,
                        f.DX0001.T008C,
                        f.DX0001.T009C,
                        f.DX0001.T010C,
                        f.DX0001.T011C,
                        f.DX0001.T012C,
                        f.DX0001.T013C,
                        f.DX0001.T014C,
                        f.DX0001.T015C,
                        f.DX0001.T016C,
                        f.DX0001.T017C,
                        f.DX0001.T018C,
                        f.DX0001.T019C,
                        f.DX0001.T020C,
                        f.DX0001.T021C,
                        f.DX0001.T022C,
                        f.DX0001.T023C,
                        f.DX0001.T024C,
                        f.DX0001.T025C,
                        f.DX0001.T026C,
                        f.DX0001.T027C,
                        f.DX0001.T028C,
                        f.DX0001.T029C,
                        f.DX0001.T030C,
                        f.DX0001.T097C,
                        f.DX0001.T098C,
                        f.DX0001.T099C,
                        f.DX0001.T100C,

                        f.DX0001.DX0011_ID,
                        f.DX0001.DX0010_ID,
                        f.DX0001.DX0070_ID,
                    }
                })
            };

            }
               
        }
    }
}
