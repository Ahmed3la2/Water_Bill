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


        public IActionResult Index()
        {
            var Rreal = _context.real_Estate_Type.ToList();
            ViewBag.Rreal = true;

            return View(Rreal);
        }

        public IActionResult create()
        {
            ViewBag.AddRreal = true;
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

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Edit(string id)
        {

            var RrealEstate = _context.real_Estate_Type.FirstOrDefault(r => r.Rreal_Estate_Types_Code == id);
            ViewBag.name = RrealEstate.Rreal_Estate_Types_Name;
            return View(RrealEstate);
        }

        [HttpPost]
        public IActionResult Edit(Rreal_Estate_Types Rreal)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Rreal_Estate_Types_Name", "وصف العقار غير متاح ادخل وصف جديد");

                return View(Rreal);
            }
            if (_context.real_Estate_Type.Any(e => e.Rreal_Estate_Types_Name == Rreal.Rreal_Estate_Types_Name))
            {
                ModelState.AddModelError("Rreal_Estate_Types_Name", "وصف العقار غير متاح ادخل وصف جديد");

                return View(Rreal);
            }

            Rreal.Rreal_Estate_Types_Name.Trim();

            var GetCurrentRreal = _context.real_Estate_Type.Update(Rreal);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }

}
