using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Water_Bill.Models
{
    public class Slice_Values
    {
        [Key]
        [Column(TypeName = "char(1)")]
        public string Slice_Values_Code { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Slice_Values_Name { get; set; }

        public int Slice_Values_Condtion { get; set; }

        [Column(TypeName = "Decimal(6,2)")]
        public double Slice_Values_Water_Price { get; set; }

        [Column(TypeName = "Decimal(6,2)")]
        public double Slice_Values_Sanitation_Price { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Slice_Values_Reasons { get; set; }


    }
}
