using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTDoanVien.Areas.Admin.Data;
using TTDoanVien.Models;

namespace TTDoanVien.Areas.Admin.Controllers
{
    public class ChiDoanController : Controller
    {
        // GET: Admin/ChiDoan
        private DatabaseDV _context = new DatabaseDV();
        public ActionResult Index()
        {
            var lstCD = (from cd in _context.ChiDoans
                         orderby cd.MaChiDoan ascending
                         select new ChiDoanMV()
                         {
                             MaChiDoan = cd.MaChiDoan,
                             TenChiDoan = cd.TenChiDoan,
                             Anh = cd.Anh,
                             NgayLap = cd.NgayThanhLap,

                         }).ToList();

            return View(lstCD);
        }
    }
}