using Microsoft.AspNetCore.Mvc;
using System.Linq;
using water_bill.Models;

namespace water_bill.Controllers
{
    public class RrealEstateController : Controller
    {
        private readonly AppDbContext _context;

        public RrealEstateController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult create(Rreal_Estate_Types Estate)
        {
            if (!ModelState.IsValid)
            {
                return View(Estate);
            }

            if (_context.real_Estate_Type.Any(e => e.Rreal_Estate_Types_Code == Estate.Rreal_Estate_Types_Code))
            {
                ModelState.AddModelError("Rreal_Estate_Types_Code", "رمز العقار غير متاح ادخل رمز جديد");
                return View(Estate);
            }
            if (_context.real_Estate_Type.Any(e => e.Rreal_Estate_Types_Name == Estate.Rreal_Estate_Types_Name))
            {
                ModelState.AddModelError("Rreal_Estate_Types_Name", "وصف العقار غير متاح ادخل وصف جديد");
                return View(Estate);
            }
            _context.real_Estate_Type.Add(Estate);
            _context.SaveChanges();

            return View();

        }
    }
}
