using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using water_bill.Models;
using Water_Bill.ViewModel;

namespace water_bill.Controllers
{
    public class SubscribtionController : Controller
    {
        private readonly AppDbContext _context;

        public SubscribtionController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var subscription = _context.subscription.Include(n => n.Subscription_File_Subscriber_Code).Include(r=> r.Subscription_File_Rreal_Estate_Types_Code).ToList();
            return View(subscription);
        }

        public IActionResult Create()
        {
            var estate = _context.real_Estate_Type.ToList();
            ViewBag.Estate = new SelectList(estate, "Rreal_Estate_Types_Code", "Rreal_Estate_Types_Name");

            int? LastNumber = _context.subscription.OrderByDescending(n => n.Number).Select(n => n.Number).FirstOrDefault();
            string currentYear = DateTime.Now.Year.ToString().Substring(DateTime.Now.Year.ToString().Length - 2);
            string CurrentMonth = DateTime.Now.Month.ToString();

            if (LastNumber == 0)
            {
                var NumOfSubcribtion = $"{currentYear}-{CurrentMonth}-1";
                ViewBag.NoOfSubcribtion = NumOfSubcribtion;
            }
            else
            {
                var NumOfSubcribtion = $"{currentYear}-{CurrentMonth}-{LastNumber}";
                ViewBag.NoOfSubcribtion = NumOfSubcribtion;
            }

            var subscription = _context.subscription.Include(n => n.Subscription_File_Subscriber_Code).ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Create(SubscribtionVM subscribtionVM)
        {
            if (!ModelState.IsValid)
            {
                var estate = _context.real_Estate_Type.ToList();
                ViewBag.Estate = new SelectList(estate, "Rreal_Estate_Types_Code", "Rreal_Estate_Types_Name");

                int? LastNumber = _context.subscription.OrderByDescending(n => n.Number).Select(n => n.Number).FirstOrDefault();
                string currentYear = DateTime.Now.Year.ToString().Substring(DateTime.Now.Year.ToString().Length - 2);
                string CurrentMonth = DateTime.Now.Month.ToString();

                if (LastNumber == 0)
                {
                    var NumOfSubcribtion = $"{currentYear}-{CurrentMonth}-1";
                    ViewBag.NoOfSubcribtion = NumOfSubcribtion;
                }
                else
                {
                    var NumOfSubcribtion = $"{currentYear}-{CurrentMonth}-{LastNumber}";
                    ViewBag.NoOfSubcribtion = NumOfSubcribtion;
                }

                return View(subscribtionVM);
            }

            Subscription_File subscriptiondto = new Subscription_File
            {
                Subscription_File_Is_There_Sanitation = subscribtionVM.Subscription_File_Is_There_Sanitation,
                Subscription_File_No = subscribtionVM.Subscription_File_No,
                Subscription_File_Unit_No = subscribtionVM.Subscription_File_Unit_No,
                Subscription_File_Rreal_Estate_Types_CodeID = subscribtionVM.Subscription_File_Rreal_Estate_Types_CodeID,
                Subscription_File_Subscriber_CodeId = subscribtionVM.Subscription_File_Subscriber_CodeId,
            };
            _context.subscription.Add(subscriptiondto);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public JsonResult getSubscriber([FromQuery] string suscode)
        {
            var subscriber = _context.subscriber.FirstOrDefault(i => i.Subscriber_File_Id == suscode);
            return Json(subscriber);
        }

        [HttpGet]
        public JsonResult getSubscriberBySusbscribtionId([FromQuery] string Subscription_No)
        {
            var subscriber = _context.subscription.Include(s => s.Subscription_File_Subscriber_Code)
                .Select(l => new
                {
                    l.Subscription_File_Is_There_Sanitation,
                    l.Subscription_File_Last_Reading_Meter,
                    subscriber = new
                    {
                        l.Subscription_File_Subscriber_Code.Subscriber_File_Name,
                        l.Subscription_File_Subscriber_Code.Subscriber_File_Mobile,
                        l.Subscription_File_Subscriber_Code.Subscriber_File_Id,
                        l.Subscription_File_Subscriber_Code.Subscriber_File_Area,    
                        l.Subscription_File_Subscriber_Code.Subscriber_File_City,       
                    },
                    l.Subscription_File_No,
                    l.Subscription_File_Rreal_Estate_Types_Code.Rreal_Estate_Types_Name,
                    l.Subscription_File_Rreal_Estate_Types_Code.Rreal_Estate_Types_Code,
                    l.Subscription_File_Unit_No
                })
                .FirstOrDefault(i => i.Subscription_File_No == Subscription_No);
            return Json(subscriber);
        }
    }
}
