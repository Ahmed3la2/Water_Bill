using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using water_bill.Models;

namespace water_bill.Controllers
{
    public class SubscriberController : Controller
    {
        private readonly AppDbContext _context;

        public SubscriberController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var subscriber = _context.subscriber.Include(s => s.Subscription).ToList();
            ViewBag.Subscriber = true;
            return View(subscriber);
        }

        public IActionResult Create()
        {
            ViewBag.IsCSubscriberCreate = true;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Subscriber_File subscriber)
        {
            if (!ModelState.IsValid)
            {
                return View(subscriber);
            }
            if (_context.subscriber.Any(e => e.Subscriber_File_Id == subscriber.Subscriber_File_Id))
            {
                ModelState.AddModelError("Subscriber_File_Id", "رقم الهويه غير متاح ادخل رقم جديد");
                return View(subscriber);
            }
    
            _context.subscriber.Add(subscriber);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(string id)
        {
            var subscriber = _context.subscriber.FirstOrDefault(s=> s.Subscriber_File_Id == id);
            return View(subscriber);
        }  
        
        [HttpPost]
        public IActionResult Edit(Subscriber_File subscriber)
        {
            if (!ModelState.IsValid)
            {
                return View(subscriber);
            }

            _context.subscriber.Update(subscriber);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public JsonResult getSubscriber([FromQuery] string suscode)
        {
            var subscriber = _context.subscriber.Include(s=>s.Subscription).FirstOrDefault(i => i.Subscriber_File_Id == "1234567891");

            var x = new
            {
                n = subscriber.Subscription.Count()
            };
            return Json(x);
        }
    }
}
