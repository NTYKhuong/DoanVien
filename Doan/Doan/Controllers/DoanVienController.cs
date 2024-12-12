 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Doan.Models;

namespace Doan.Controllers
{
    public class DoanVienController : Controller
    {
        private readonly DBDoanVienContext _context;
        public ActionResult Index()
        {
            var doanVienList = _context.DoanViens.Include("ChiDoan").ToList();

            return View(doanVienList);
        }
    }
}