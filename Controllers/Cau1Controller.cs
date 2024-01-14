using Microsoft.AspNetCore.Mvc;
using ococ.Models;
namespace ococ.Controllers
{
    public class Cau1Controller : Controller
    {
        private readonly QuanLyChuyenBayContext _context;

        public Cau1Controller(QuanLyChuyenBayContext context)
        {
            _context = context;
        }

        public IActionResult Cau1()
        {
            return View();
        }
        public IActionResult ThemHanhKhach(Hanhkhach hk) {
            _context.Hanhkhaches.Add(hk);
            _context.SaveChanges();
            return View("Cau1");
        }

    }
}
