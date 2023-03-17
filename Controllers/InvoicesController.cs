using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using water_bill;
using Water_Bill.Models;
using Water_Bill.ViewModel;

namespace Water_Bill.Controllers
{
    public class InvoicesController : Controller
    {
        public AppDbContext _context;

        public InvoicesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var invoices = _context.Invoices.Include(s => s.Invoices_Subscription_No).Include(s=>s.Invoices_Subscriber_No).ToList();

            return View(invoices);
        }

        public IActionResult Create()
        {
            int? LastNumber = _context.Invoices.OrderByDescending(n => n.Number).Select(n => n.Number).FirstOrDefault();
            string currentYear = DateTime.Now.Year.ToString();
            string CurrentMonth = DateTime.Now.Month.ToString();

            if (LastNumber == 0)
            {
                var NumOfSubcribtion = $"{currentYear}-{CurrentMonth}-1";
                ViewBag.NoOfInvoice = NumOfSubcribtion;
            }
            else
            {
                var NumOfSubcribtion = $"{currentYear}-{CurrentMonth}-{LastNumber}";
                ViewBag.NoOfInvoice = NumOfSubcribtion;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(InvoicesVM invoices)
        {
            if (!ModelState.IsValid)
            {
                int? LastNumber = _context.Invoices.OrderByDescending(n => n.Number).Select(n => n.Number).FirstOrDefault();
                string currentYear = DateTime.Now.Year.ToString();
                string CurrentMonth = DateTime.Now.Month.ToString();
                if (LastNumber == 0)
                {
                    var NumOfSubcribtion = $"{currentYear}-{CurrentMonth}-1";
                    ViewBag.NoOfInvoice = NumOfSubcribtion;
                }
                else
                {
                    var NumOfSubcribtion = $"{currentYear}-{CurrentMonth}-{LastNumber}";
                    ViewBag.NoOfInvoice = NumOfSubcribtion;
                }

                return View(invoices);
            }

            var invoice = new Invoices
            {
                Invoices_No = invoices.Invoices_No,
                Invoices_Year = DateTime.Now.Year.ToString(),
                Invoices_Rreal_Estate_TypesId = invoices.Invoices_Rreal_Estate_TypesId,
                Invoices_Subscriber_NoId = invoices.Invoices_Subscriber_NoId,
                Invoices_Subscription_NoId = invoices.Invoices_Subscription_NoId,
                Invoices_Date = invoices.Invoices_Date,
                Invoices_From = invoices.Invoices_From,
                Invoices_To = invoices.Invoices_To,
                Invoices_Previous_Consumption_Amount = invoices.Invoices_Previous_Consumption_Amount,
                Invoices_Current_Consumption_Amount = invoices.Invoices_Current_Consumption_Amount,
                Invoices_Amount_Consumption = invoices.Invoices_Amount_Consumption,
                Invoices_Total_Invoice = invoices.Invoices_Total_Invoice,
                Invoices_Total_Bill = invoices.Invoices_Total_Bill,
                Invoices_Wastewater_Consumption_Value = invoices.Invoices_Wastewater_Consumption_Value,
                Invoices_Consumption_Value = invoices.Invoices_Consumption_Value,

            };

            var susbscriper = _context.subscription.FirstOrDefault(i => i.Subscription_File_No == invoices.Invoices_Subscription_NoId);
            susbscriper.Subscription_File_Last_Reading_Meter = invoices.Invoices_Current_Consumption_Amount;

            _context.SaveChanges();


            _context.Invoices.Add(invoice);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public JsonResult Get_Amount_Consumption_Value([FromQuery] bool sanitation, [FromQuery] int noOfUnit, [FromQuery] double Amount_Consumption)
        {
            if (noOfUnit <= 0 || Amount_Consumption <= 0) return Json(null);

            var slices = _context.slice_Value
                              .OrderBy(l => l.Slice_Values_Condtion)
                              .Select(u => new { condition = u.Slice_Values_Condtion * noOfUnit, u.Slice_Values_Water_Price, u.Slice_Values_Sanitation_Price })
                              .ToList();
            double Amount_Water_Value = 0;
            double Amount_sanitation_Value = 0;
            int i = 0;
            do
            {
                if (Amount_Consumption <= slices[0].condition)
                {
                    Amount_Water_Value = Amount_Consumption * (slices[0].Slice_Values_Water_Price);
                    Amount_sanitation_Value = Amount_Consumption * (slices[0].Slice_Values_Sanitation_Price);


                    return Json(new
                    {
                        Amount_Consumption_Value = Convert.ToDouble(Amount_Water_Value.ToString("N3")),
                        Amount_sanitation_Value = sanitation ? Convert.ToDouble(Amount_sanitation_Value.ToString("N3")) : 0,
                        totalOfConsumpton = sanitation ? Convert.ToDouble((Amount_Water_Value + Amount_sanitation_Value).ToString("N3")) : Convert.ToDouble((Amount_Water_Value + 0).ToString("N3"))

                    });
                }
                if (Amount_Consumption > slices[i].condition && Amount_Consumption <= slices[i + 1].condition || Amount_Consumption > slices[slices.Count() - 1].condition)
                {
                    var y = slices.Where(x => x.condition >= Amount_Consumption).FirstOrDefault();

                    var CurrentSlices = (y == null) ? slices.ToList() : slices.Where(x => x.Slice_Values_Water_Price <= y.Slice_Values_Water_Price).ToList();

                    var CurrentSlicesCount = CurrentSlices.Count();

                    foreach (var item in CurrentSlices.Select((x, y) => new { Value = x, Index = y }))
                    {
                        if (item.Index == CurrentSlicesCount - 1)
                        {
                            Amount_Water_Value += ((Amount_Consumption - CurrentSlices[item.Index - 1].condition)) * (item.Value.Slice_Values_Water_Price);
                            Amount_sanitation_Value += ((Amount_Consumption - CurrentSlices[item.Index - 1].condition)) * (item.Value.Slice_Values_Sanitation_Price);
                        }
                        else
                        {
                            if (item.Index == 0)
                            {
                                Amount_Water_Value += ((item.Value.condition - 0) * (item.Value.Slice_Values_Water_Price));
                                Amount_sanitation_Value += ((item.Value.condition - 0) * (item.Value.Slice_Values_Sanitation_Price));
                            }
                            else
                            {
                                Amount_Water_Value += ((item.Value.condition - CurrentSlices[item.Index - 1].condition)) * (item.Value.Slice_Values_Water_Price);
                                Amount_sanitation_Value += ((item.Value.condition - CurrentSlices[item.Index - 1].condition)) * (item.Value.Slice_Values_Sanitation_Price);
                            }
                        }
                    }
                }
                if (Amount_Water_Value != 0 || Amount_sanitation_Value != 0) break;

                i++;

            } while (i <= slices.Count() - 1);

            return Json(new
            {
                Amount_Consumption_Value = Convert.ToDouble(Amount_Water_Value.ToString("N3")),
                Amount_sanitation_Value = sanitation ? Convert.ToDouble(Amount_sanitation_Value.ToString("N3")) : 0,
                totalOfConsumpton = sanitation ? Convert.ToDouble((Amount_Water_Value + Amount_sanitation_Value).ToString("N3")) : Convert.ToDouble((Amount_Water_Value + 0).ToString("N3"))
            });


        }








        private JsonResult GetConWithSan(int noOfUnit, double Amount_Consumption)
        {
            var slices = _context.slice_Value
                               .Select(u => new { condition = u.Slice_Values_Condtion * noOfUnit, u.Slice_Values_Water_Price, u.Slice_Values_Sanitation_Price })
                               .ToList();
            double Amount_Water_Value = 0;
            double Amount_sanitation_Value = 0;
            if (Amount_Consumption <= slices[0].condition)
            {
                Amount_Water_Value = Amount_Consumption * (slices[0].Slice_Values_Water_Price);

                Amount_sanitation_Value = Amount_Consumption * (slices[0].Slice_Values_Sanitation_Price);


                return Json(new
                {
                    Amount_Consumption_Value = Convert.ToDouble(Amount_Water_Value.ToString("N3")),
                    Amount_sanitation_Value = Convert.ToDouble(Amount_sanitation_Value.ToString("N3"))
                });

            }
            else if (Amount_Consumption > slices[0].condition && Amount_Consumption <= slices[1].condition)
            {
                Amount_Water_Value = slices[0].condition
                                        * (slices[0].Slice_Values_Water_Price) + ((Amount_Consumption) - (slices[0].condition * 1))
                                        * (slices[1].Slice_Values_Water_Price);

                Amount_sanitation_Value = slices[0].condition
                                        * (slices[0].Slice_Values_Sanitation_Price) + ((Amount_Consumption) - (slices[0].condition * 1))
                                        * (slices[1].Slice_Values_Sanitation_Price);
                return Json(new
                {
                    Amount_Consumption_Value = Convert.ToDouble(Amount_Water_Value.ToString("N3")),
                    Amount_sanitation_Value = Convert.ToDouble(Amount_sanitation_Value.ToString("N3"))
                });
            }
            else if (Amount_Consumption > slices[1].condition && Amount_Consumption <= slices[2].condition)
            {
                Amount_Water_Value = slices[0].condition
                                         * (slices[0].Slice_Values_Water_Price) + (slices[0].condition)
                                         * (slices[1].Slice_Values_Water_Price) + ((Amount_Consumption) - (slices[0].condition * 2))
                                         * (slices[2].Slice_Values_Water_Price);

                Amount_sanitation_Value = slices[0].Slice_Values_Sanitation_Price
                                         * (slices[0].Slice_Values_Sanitation_Price) + (slices[0].condition)
                                         * (slices[1].Slice_Values_Sanitation_Price) + ((Amount_Consumption) - (slices[0].condition * 2))
                                         * (slices[2].Slice_Values_Sanitation_Price);
                return Json(new
                {
                    Amount_Consumption_Value = Convert.ToDouble(Amount_Water_Value.ToString("N3")),
                    Amount_sanitation_Value = Convert.ToDouble(Amount_sanitation_Value.ToString("N3"))
                });
            }
            else if (Amount_Consumption > slices[2].condition && Amount_Consumption <= slices[3].condition)
            {
                Amount_Water_Value = slices[0].condition
                                         * (slices[0].Slice_Values_Water_Price) + (slices[0].condition)
                                         * (slices[1].Slice_Values_Water_Price) + (slices[0].condition)
                                         * (slices[2].Slice_Values_Water_Price) + ((Amount_Consumption) - (slices[0].condition * 3))
                                         * (slices[3].Slice_Values_Water_Price);

                Amount_sanitation_Value = slices[0].condition
                                        * (slices[0].Slice_Values_Sanitation_Price) + (slices[0].condition)
                                        * (slices[1].Slice_Values_Sanitation_Price) + (slices[0].condition)
                                        * (slices[2].Slice_Values_Sanitation_Price) + ((Amount_Consumption) - (slices[0].condition * 3))
                                        * (slices[3].Slice_Values_Sanitation_Price);
                return Json(new
                {
                    Amount_Consumption_Value = Convert.ToDouble(Amount_Water_Value.ToString("N3")),
                    Amount_sanitation_Value = Convert.ToDouble(Amount_sanitation_Value.ToString("N3"))
                });
            }
            else
            {
                Amount_Water_Value = slices[0].condition
                                        * (slices[0].Slice_Values_Water_Price) + (slices[0].condition)
                                        * (slices[1].Slice_Values_Water_Price) + (slices[0].condition)
                                        * (slices[2].Slice_Values_Water_Price) + (slices[0].condition)
                                        * (slices[3].Slice_Values_Water_Price) + ((Amount_Consumption) - (slices[0].condition * 4))
                                        * (slices[4].Slice_Values_Water_Price);

                Amount_sanitation_Value = slices[0].condition
                                       * (slices[0].Slice_Values_Sanitation_Price) + (slices[0].condition)
                                       * (slices[1].Slice_Values_Sanitation_Price) + (slices[0].condition)
                                       * (slices[2].Slice_Values_Sanitation_Price) + (slices[0].condition)
                                       * (slices[3].Slice_Values_Sanitation_Price) + ((Amount_Consumption) - (slices[0].condition * 4))
                                       * (slices[4].Slice_Values_Sanitation_Price);
                return Json(new
                {
                    Amount_Consumption_Value = Convert.ToDouble(Amount_Water_Value.ToString("N3")),
                    Amount_sanitation_Value = Convert.ToDouble(Amount_sanitation_Value.ToString("N3"))
                });
            }
        }
        private JsonResult GetConsuWithoutSani(int noOfUnit, double Amount_Consumption)
        {
            var slices = _context.slice_Value
                               .Select(u => new { condition = u.Slice_Values_Condtion * noOfUnit, u.Slice_Values_Water_Price, u.Slice_Values_Sanitation_Price })
                               .ToList();
            double Amount_Water_Value = 0;
            if (Amount_Consumption <= slices[0].condition)
            {
                Amount_Water_Value = Amount_Consumption * (slices[0].Slice_Values_Water_Price);

                return Json(new
                {
                    Amount_Water_Value = Convert.ToDouble(Amount_Water_Value.ToString("N3")),
                    Amount_sanitation_Value = 0
                });

            }
            else if (Amount_Consumption > slices[0].condition && Amount_Consumption <= slices[1].condition)
            {
                Amount_Water_Value = slices[0].condition
                                        * (slices[0].Slice_Values_Water_Price) + ((Amount_Consumption) - (slices[0].condition * 1))
                                        * (slices[1].Slice_Values_Water_Price);
                return Json(new
                {
                    Amount_Water_Value = Convert.ToDouble(Amount_Water_Value.ToString("N3")),
                    Amount_sanitation_Value = 0
                });
            }
            else if (Amount_Consumption > slices[1].condition && Amount_Consumption <= slices[2].condition)
            {
                Amount_Water_Value = slices[0].condition
                                         * (slices[0].Slice_Values_Water_Price) + (slices[0].condition)
                                         * (slices[1].Slice_Values_Water_Price) + ((Amount_Consumption) - (slices[0].condition * 2))
                                         * (slices[2].Slice_Values_Water_Price);
                return Json(new
                {
                    Amount_Water_Value = Convert.ToDouble(Amount_Water_Value.ToString("N3")),
                    Amount_sanitation_Value = 0
                });
            }
            else if (Amount_Consumption > slices[2].condition && Amount_Consumption <= slices[3].condition)
            {
                Amount_Water_Value = slices[0].condition
                                         * (slices[0].Slice_Values_Water_Price) + (slices[0].condition)
                                         * (slices[1].Slice_Values_Water_Price) + (slices[0].condition)
                                         * (slices[2].Slice_Values_Water_Price) + ((Amount_Consumption) - (slices[0].condition * 3))
                                         * (slices[3].Slice_Values_Water_Price);
                return Json(new
                {
                    Amount_Water_Value = Convert.ToDouble(Amount_Water_Value.ToString("N3")),
                    Amount_sanitation_Value = 0
                });
            }
            else
            {
                Amount_Water_Value = slices[0].condition
                                        * (slices[0].Slice_Values_Water_Price) + (slices[0].condition)
                                        * (slices[1].Slice_Values_Water_Price) + (slices[0].condition)
                                        * (slices[2].Slice_Values_Water_Price) + (slices[0].condition)
                                        * (slices[3].Slice_Values_Water_Price) + ((Amount_Consumption) - (slices[0].condition * 4))
                                        * (slices[4].Slice_Values_Water_Price);
                return Json(new
                {
                    Amount_Water_Value = Convert.ToDouble(Amount_Water_Value.ToString("N3")),
                    Amount_sanitation_Value = 0
                });
            }
        }

    }
}
