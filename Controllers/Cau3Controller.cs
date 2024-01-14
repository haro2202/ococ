using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ococ.Models;

namespace ococ.Controllers
{
    public class Cau3Controller : Controller
    {
        QuanLyChuyenBayContext _context;
        public Cau3Controller(QuanLyChuyenBayContext context)
        {
            _context = context;
        }
        public IActionResult ViewThemhanhkhach(string mach)
        {
            ViewBag.mach = mach;
            ViewBag.chuyenbay = _context.Chuyenbays.Find(mach);
            ViewBag.sochovip = _context.CtCbs.Where(ct => ct.Mach == mach && ct.Loaighe == true).Count();
            ViewBag.sochothuong = _context.CtCbs.Where(ct => ct.Mach == mach && ct.Loaighe == false).Count();
            return View();
        }
        public IActionResult ThemHanhKhach()
        {
            _context.CtCbs.Add(new CtCb
            {
                Mach = Request.Form["mach"],
                Mahk = Request.Form["mahk"],
                Soghe = Request.Form["soghe"],
                Loaighe = Request.Form["loaighe"] == "true" ? true : false
            }) ;
            _context.SaveChanges();
            return RedirectToAction("XemThongTinChuyenBay", "Cau2", new { machuyenbay = Request.Form["mach"] });
        }
        public IActionResult XoaHanhKhach(string mach, string mahk)
        {
            _context.CtCbs.Remove(_context.CtCbs.Where(ct => ct.Mach == mach && ct.Mahk == mahk).First());
            _context.SaveChanges();
            return RedirectToAction("XemThongTinChuyenBay", "Cau2", new { machuyenbay = mach });
        }
        public IActionResult ViewSua(string mach, string mahk)
        {
            ViewBag.mach = mach;
            ViewBag.mahk = mahk;
            ViewBag.ctcb = _context.CtCbs.Where(ct => ct.Mach == mach && ct.Mahk == mahk).Include(ct=>ct.HanhKhach).First();
            return View();
        }
        public IActionResult SuaHanhKhach()
        {
            CtCb ctcb = _context.CtCbs.Where(ct => ct.Mach == Request.Form["mach"] && ct.Mahk == Request.Form["mahk"]).First();
            ctcb.Soghe = Request.Form["soghe"];
            ctcb.Loaighe = Request.Form["loaighe"] == "true" ? true : false;
            _context.SaveChanges();
            return RedirectToAction("XemThongTinChuyenBay", "Cau2", new { machuyenbay = Request.Form["mach"] });
        }
    }
}
