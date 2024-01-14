using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ococ.Models;
namespace ococ.Controllers
{
    public class Cau2Controller : Controller
    {
        private readonly QuanLyChuyenBayContext _context;

        public Cau2Controller(QuanLyChuyenBayContext context)
        {
            _context = context;
        }

        public IActionResult Cau2()
        {
            return View();
        }
        public IActionResult XemThongTinChuyenBay(string machuyenbay)
        {
            ViewBag.machuyenbay = machuyenbay;
            ViewBag.chuyenbay = _context.Chuyenbays.Find(machuyenbay);
            ViewBag.ctcb = _context.CtCbs.Include(ct => ct.HanhKhach).Where(ct => ct.Mach == machuyenbay);
            ViewBag.sochovip = _context.CtCbs.Where(ct => ct.Mach == machuyenbay && ct.Loaighe == true).Count();
            ViewBag.sochothuong = _context.CtCbs.Where(ct => ct.Mach == machuyenbay && ct.Loaighe == false).Count();
            return View("ChiTietChuyenBay");
        }
    }
}
