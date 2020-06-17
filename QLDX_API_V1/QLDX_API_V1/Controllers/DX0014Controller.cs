using QLDX_API_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLDX_API_V1.Controllers
{
    [RoutePrefix("api/DX0014")]
    public class DX0014Controller : ApiController
    {
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage add([FromBody]DX0014[] values)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                results<object> list = new results<object>();
                values.ToList().ForEach(val => {
                    result<object> rel = new result<object>();
                    var check = db.DX0014.SingleOrDefault(p => p.DX0014_ID == val.DX0014_ID);
                    if (check == null)
                    {
                        db.DX0014.Add(val);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", getDX0014(val));

                        }
                        catch (Exception d)
                        {
                            rel.set("ERR", val, d.Message);
                        }
                    }
                    else
                    {
                        check.ghiChu = val.ghiChu;
                        check.tenDiaDanh = val.tenDiaDanh;
                        check.trangThai = val.trangThai;
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", getDX0014(check));

                        }
                        catch (Exception d)
                        {
                            rel.set("ERR", getDX0014(check), d.Message);
                        }
                    }
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }

        [Route("delete")]
        [HttpPost]
        public HttpResponseMessage delete([FromBody]DX0014[] values)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                results<object> list = new results<object>();
                values.ToList().ForEach(val => {
                    result<object> rel = new result<object>();
                    var check = db.DX0014.SingleOrDefault(p => p.DX0014_ID == val.DX0014_ID);
                    if (check != null)
                    {
                        db.DX0014.Remove(check);
                        try
                        {
                            db.SaveChanges();
                            rel.set("OK", getDX0014(val));

                        }
                        catch (Exception d)
                        {
                            rel.set("ERR", val, d.Message);
                        }
                    }
                    else
                    {
                        rel.set("NOT_EXIST", getDX0014(val));
                    }
                    list.add(rel);
                });
                return list.ToHttpResponseMessage();
            }
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage getall()
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                var data = db.DX0014.Where(f => f.trangThai == true).Select(p => new
                {
                    p.DX0014_ID,
                    p.ghiChu,
                    p.tenDiaDanh,
                    p.trangThai,
                    //DX0011 = p.DX0011.Select(g => new { g.DX0011_ID,g.DX0013_ID,g.DX0014_ID,g.ghiChu,g.lat,g.lng,g.maDiemDon,g.taxi,g.tenDiemDon,g.thuTu,g.trangThai})
                });
                return REST.GetHttpResponseMessFromObject(data);
            }
        }

        [Route("getall2")]
        [HttpGet]
        public HttpResponseMessage getall2()
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                var data = db.DX0014.Where(f => f.trangThai == true).Select(p => new
                {
                    p.DX0014_ID,
                    p.ghiChu,
                    p.tenDiaDanh,
                    p.trangThai,
                    DX0011 = p.DX0011.Select(g => new { g.DX0011_ID,g.DX0013_ID,g.DX0014_ID,g.ghiChu,g.lat,g.lng,g.maDiemDon,g.taxi,g.tenDiemDon,g.thuTu,g.trangThai})
                });
                return REST.GetHttpResponseMessFromObject(data);
            }
        }

        [Route("getallLocation/{DX0014_ID}")]
        [HttpGet]
        public HttpResponseMessage getallLocation(string DX0014_ID)
        {
            using (QLDX_DB db = new QLDX_DB())
            {
                var data = db.DX0011.Where(x => x.DX0014_ID == DX0014_ID).Select(g => new { g.DX0011_ID, g.DX0013_ID, g.DX0014_ID, g.ghiChu, g.lat, g.lng, g.maDiemDon, g.taxi, g.tenDiemDon, g.thuTu, g.trangThai });
                return REST.GetHttpResponseMessFromObject(data);
            }
        }
        public object getDX0014(DX0014 val)
        {
            return new
            {
                val.DX0014_ID,
                val.ghiChu,
                val.tenDiaDanh,
                val.trangThai,
                DX0011 = val.DX0011==null?null: val.DX0011.Select(p => new
                {
                    p.DX0011_ID,
                    p.DX0013_ID,
                    p.DX0014_ID,
                    p.ghiChu,
                    p.lat,
                    p.lng,
                    p.maDiemDon,
                    p.taxi,
                    p.tenDiemDon,
                    p.thuTu,
                    p.trangThai,
                    DX0020 =p.DX0020==null?null: p.DX0020.Select(b => new
                    {
                        b.ban_id,
                        b.capbac,
                        b.chucvu,
                        b.cmtnd_so,
                        b.diachitamtru,
                        b.diachithuongtru,
                        b.dienthoai_didong,
                        b.DX0011_ID,
                        b.DX0020_ID,
                        b.email,
                        b.gioitinh,
                        b.hodem,
                        b.manhansu,
                        b.ngaysinh,
                        b.phong_id,
                        b.ten,
                        b.thetu_id,
                        b.trangThai
                    })
                })
            };
        }
    }
}
