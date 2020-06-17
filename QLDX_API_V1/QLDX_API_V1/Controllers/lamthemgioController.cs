using QLDX_API_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLDX_API_V1.Controllers
{
    [RoutePrefix("api/lamthemgio")]
    public class lamthemgioController : ApiController
    {
        public struct filter
        {
            public string DX0070_ID { get; set; }
            public Nullable<int> trangThai { get; set; }
            public Nullable<bool> ngaytao { get; set; }
        }
        [Route("getall")]
        [HttpPost]
        public HttpResponseMessage getall(filter filter)
        { var test = DateTime.Parse(DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day);
            using (QLDX_DB db = new QLDX_DB())
            {
                DateTime oo=new DateTime();
                var data = db.DX0010.AsEnumerable().Where(p => p.trangThai == true && p.type == 3).Select(p => new
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
                            o.DX0011.maDiemDon,
                            o.DX0011.taxi,
                            o.DX0011.tenDiemDon,
                            o.DX0011.thuTu,
                            o.DX0011.trangThai
                                
                        },
                        count =db.DX0001.AsEnumerable().Where(a=>
                        a.trangThai==2&&
                        a.maForm=="SF015" &&
                        a.T007C==filter.DX0070_ID&&
                        db.DX0020.Where(vv=>vv.DX0011_ID==o.DX0011_ID).Select(vv=>vv.manhansu).Contains( a.T002C)&&
                       ( DateTime.TryParse( a.ngayTao,out oo)?oo>=test:false)
                        )

                    }).OrderBy(f => f.thuTu),
                    });
                return REST.GetHttpResponseMessFromObject(data);
            }
        }
        [Route("Getdondangkylamthem")]
        [HttpPost]
        public HttpResponseMessage Getdondangkylamthem([FromBody]filter filter)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                var data = db.Database.SqlQuery<DX0001>(@"select * from DX0001 where maForm='SF015' "+(filter.trangThai!=null? ("and trangThai="+filter.trangThai) : "")
                    +(filter.ngaytao==null?"": (filter.ngaytao == true ? "and CONVERT(date, ngaytao, 111)<CONVERT(date, getdate(), 111)" : "and CONVERT(date, ngaytao, 111)>=CONVERT(date, getdate(), 111)"))
                    );
                return REST.GetHttpResponseMessFromObject(data);
            }
        }
    }
}
