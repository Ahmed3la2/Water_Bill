using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using water_bill.Models;

namespace Water_Bill.Models
{
    public class Invoices
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Number { get; set; }

        [Key]
        [Column(TypeName = "char(10)")]
        public string Invoices_No { get; set; }

        [Column(TypeName = "char(4)")]
        public string Invoices_Year { get; set; }

        [Column(TypeName = "char(2)")]
        public string Invoices_Rreal_Estate_TypesId { get; set; }
        public Rreal_Estate_Types Invoices_Rreal_Estate_Types { get; set; }

        [Column(TypeName = "char(10)")]
        public string Invoices_Subscription_NoId { get; set; }
        public Subscription_File Invoices_Subscription_No { get; set; }

        [Column(TypeName = "char(10)")]
        public string Invoices_Subscriber_NoId { get; set; }
        public Subscriber_File Invoices_Subscriber_No { get; set; }

        public DateTime Invoices_Date { get; set; }

        public DateTime Invoices_From { get; set; }

        public DateTime Invoices_To { get; set; }

        public int Invoices_Previous_Consumption_Amount { get; set; }

        public int Invoices_Current_Consumption_Amount { get; set; }

        public int Invoices_Amount_Consumption { get; set; }

        [Column(TypeName = "Decimal(6,2)")]
        public double Invoices_Service_Fee { get; set; }
        
        [Column(TypeName = "Decimal(6,2)")]
        public double Invoices_Tax_Rate { get; set; }

        public bool Invoices_Is_There_Sanitation { get; set; }

        [Column(TypeName = "Decimal(10,2)")]
        public double Invoices_Consumption_Value { get; set; }
        
        [Column(TypeName = "Decimal(10,2)")]
        public double Invoices_Wastewater_Consumption_Value { get; set; }
        
        [Column(TypeName = "Decimal(10,2)")]
        public double Invoices_Total_Invoice { get; set; } 
        
        [Column(TypeName = "Decimal(10,2)")]
        public double Invoices_Tax_Value { get; set; }      
        
        [Column(TypeName = "Decimal(10,2)")]
        public double Invoices_Total_Bill { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Invoices_Total_Reasons  { get; set; }

    }
}
