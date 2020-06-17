
using QLDX_API_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLDX_API_V1.Controllers
{
    [RoutePrefix("api/DX0001")]
    public class DX0001Controller : ApiController
    {
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
                    var check = db.DX0001.Where(p => p.A0028_ID == val.A0028_ID).FirstOrDefault();
                    if (check == null)
                    {
                        db.DX0001.Add(val);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", getDX0001(val));
                        }
                        catch (Exception f)
                        {
                            rel.set("ERR", getDX0001(val), f.Message);
                        }
                    }
                    else
                    {
                        rel.set("EXIST", getDX0001(check));
                    }
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }
        public struct filter
        {
            public string maform { get; set; }
            public string id { get; set; }
        }
        [Route("Getdondangkymoi1")]
        [HttpGet]
        public HttpResponseMessage Getdondangkymoi1()
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                var data = db.Database.SqlQuery<DX0001>(@"select * from DX0001 where maForm='SF014' and trangThai=1");
                return REST.GetHttpResponseMessFromObject(data);
            }
        }
        [Route("Getdondangkymoi2")]
        [HttpGet]
        public HttpResponseMessage Getdondangkymoi2()
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                var data = db.Database.SqlQuery<DX0001>(@"select * from DX0001 where maForm='SF014' and trangThai=2");
                return REST.GetHttpResponseMessFromObject(data);
            }
        }
        [Route("Getdondangky")]
        [HttpGet]
        public HttpResponseMessage Getdondangky()
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                var data = db.Database.SqlQuery<DX0001>(@"select * from DX0001 where maForm='SF014'");
                return REST.GetHttpResponseMessFromObject(data);
            }
        }
        [Route("Getdondicongtac/{trangThai}")]
        [HttpGet]
        public HttpResponseMessage Getdondicongtac(string trangThai)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                var sqlcmd = trangThai == "1" ? " select * from DX0001 where maForm = 'SF013' and trangThai = 1 "
                    : trangThai == "2" ? "select * from DX0001 where maForm='SF013' and trangThai=2 "
                    : trangThai == "3" ? "select * from DX0001 where maForm='SF013' and trangThai=3 and  CONVERT(date,T012C,23)<GETDATE()"
                    : "select * from DX0001 where maForm='SF013'";
                var data =   db.Database.SqlQuery<DX0001>(sqlcmd);
                return REST.GetHttpResponseMessFromObject(data);
            }
        }


        [Route("Getdondangkylamthem1")]
        [HttpGet]
        public HttpResponseMessage Getdondangkylamthem1()
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                var data = db.Database.SqlQuery<DX0001>(@"select * from DX0001 where maForm='SF015' and trangThai=1");
                return REST.GetHttpResponseMessFromObject(data);
            }
        }
        [Route("Getdondangkylamthem2")]
        [HttpGet]
        public HttpResponseMessage Getdondangkylamthem2()
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                var data = db.Database.SqlQuery<DX0001>(@"select * from DX0001 where maForm='SF015' and trangThai=2");
                return REST.GetHttpResponseMessFromObject(data);
            }
        }
        [Route("Getdondangky/{id}")]
        [HttpGet]
        public HttpResponseMessage Getdondangky(string id)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                var data = db.Database.SqlQuery<DX0001>(@"select * from DX0001 where DX0001_ID='" + id + "'").FirstOrDefault();
                return REST.GetHttpResponseMessFromObject(data);
            }
        }
        [Route("update")]
        [HttpPost]
        public HttpResponseMessage update([FromBody]DX0001[]values)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                results<object> list = new results<object>();
                values.ToList().ForEach(val =>
                {
                    result<object> rel = new result<object>();
                    var check = db.DX0001.Where(p => p.DX0001_ID == val.DX0001_ID&&p.trangThai != val.trangThai).FirstOrDefault();
                    if (check != null)
                    {
                        check.trangThai = val.trangThai;
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK",getDX0001(check));
                        }
                        catch (Exception f)
                        {
                            rel.set("ERR", getDX0001(check),f.Message);
                        }
                    }
                    else {
                        rel.set("NOT_EXIST", getDX0001(val));
                        }
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }
        [Route("delete")]
        [HttpPost]
        public HttpResponseMessage delete([FromBody]DX0001[] values)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                results<object> list = new results<object>();
                values.ToList().ForEach(val =>
                {
                    result<object> rel = new result<object>();
                    var check = db.DX0001.SingleOrDefault(p => p.DX0001_ID == val.DX0001_ID);
                    if (check != null)
                    {
                        db.DX0001.Remove(check);
                        try
                        {
                            db.SaveChanges();
                            rel.set("DELETE", getDX0001(check));
                        }
                        catch (Exception f)
                        {
                            rel.set("ERR", getDX0001(check), f.Message);
                        }
                    }
                    else
                    {
                        rel.set("NOT_EXIST", getDX0001(val));
                    }
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }
        public object getDX0001(DX0001 p)
        {
            return new
            {
                p. DX0001_ID ,
        p. A0028_ID ,
        p. A0002_ID ,
        p. hoVaTen ,
        p. A0016_ID ,
        p. A0022_ID ,
        p. A0032_ID ,
        p. maForm ,
        p. trangThai ,
        p. ngayTao ,
        p. noiDungCongViec ,
                p.daXoa ,
                p.tinhtrang ,
        p. T001C ,
        p. T002C ,
        p. T003C ,
        p. T004C ,
        p. T005C ,
        p. T006C ,
        p. T007C ,
        p. T008C ,
        p. T009C ,
        p. T010C ,
        p. T011C ,
        p. T012C ,
        p. T013C ,
        p. T014C ,
        p. T015C ,
        p. T016C ,
        p. T017C ,
        p. T018C ,
        p. T019C ,
        p. T020C ,
        p. T021C ,
        p. T022C ,
        p. T023C ,
        p. T024C ,
        p. T025C ,
        p. T026C ,
        p. T027C ,
        p. T028C ,
        p. T029C ,
        p. T030C ,
        p. T097C ,
        p. T098C ,
        p. T099C ,
        p. T100C ,

        p. DX0011_ID ,
        p. DX0010_ID ,
        p. DX0070_ID ,
         DX0011= p.DX0011==null?null: new {
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
         } ,
         DX0010= p.DX0010 == null ? null : new
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
         },
         DX0070 = p.DX0070 == null ? null : new
         {
             p.DX0070.DX0070_ID,
             p.DX0070.ghiChu,
             p.DX0070.tenKhungGio,
             p.DX0070.timeMax,
             p.DX0070.timeMin,
             p.DX0070.trangThai
         }
    };
        }
    }
}
