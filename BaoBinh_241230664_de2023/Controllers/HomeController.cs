using BaoBinh_241230664_de2023.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace BaoBinh_241230664_de2023.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlhangHoaContext _db;
        public HomeController(QlhangHoaContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var ds = _db.HangHoas.Where(h=>h.Gia>=100).ToList();
            return View(ds);
        }
        // cau 4 ajax
        public IActionResult LocTheoLoai(int? maLoai)
        {
            var q = _db.HangHoas.AsQueryable();
            if(maLoai != null)
            {
                q = q.Where(h => h.MaLoai == maLoai);
            }
            else q=q.Where(h => h.Gia >= 100);
            return PartialView("BaoBinh_MainContent", q.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(_db.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }
        [HttpPost]
        public IActionResult Create(HangHoa hh)
        {
            ModelState.Remove("MaLoaiNavigation");

            if (ModelState.IsValid)
            {
                _db.HangHoas.Add(hh);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(_db.LoaiHangs, "MaLoai", "TenLoai", hh.MaLoai);
            return View(hh);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
