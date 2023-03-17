using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Water_Bill.ViewModel
{
    public class InvoicesVM
    {
        [MaxLength(10)]
       
        public string Invoices_No { get; set; }

        public string Invoices_Rreal_Estate_TypesId { get; set; }

        [MaxLength(8)]
        [Required(ErrorMessage = "ادخل رقم الاشتراك")]
        public string Invoices_Subscription_NoId { get; set; }

        public string Invoices_Subscriber_NoId { get; set; }

        [Required(ErrorMessage = "تاريخ الفاتوره")]
        [DataType(DataType.Date)]
        public DateTime Invoices_Date { get; set; }

        [Required(ErrorMessage = "من تاريخ")]
        [DataType(DataType.Date)]
        public DateTime Invoices_From { get; set; }

        public DateTime Invoices_To { get; set; } = DateTime.Now;

        public int Invoices_Previous_Consumption_Amount { get; set; }

        public int Invoices_Current_Consumption_Amount { get; set; }

        public int Invoices_Amount_Consumption { get; set; }

        [DefaultValue(0)]
        public double Invoices_Service_Fee { get; set; }

        [DefaultValue(0)]
        public double Invoices_Tax_Rate { get; set; }

        public double Invoices_Wastewater_Consumption_Value { get; set; }

        public double Invoices_Consumption_Value { get; set; }

        public string Invoices_Is_There_Sanitation { get; set; }

        public double Invoices_Total_Invoice { get; set; }

        public double Invoices_Total_Bill { get; set; }

        public string Name { get; set; }

        public int Unit_No { get; set; }
    }
}
