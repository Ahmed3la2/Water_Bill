using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace water_bill.Models
{
    public class Rreal_Estate_Types
    {
        [Key]
        [Column(TypeName = "char(2)")]
        [Required(ErrorMessage = "ادخل رمو نوع العقار")]
        [MaxLength(2)]
        public string Rreal_Estate_Types_Code { get; set; }

        [Required(ErrorMessage = " ادخل وصف نوع العقار")]
        [MaxLength(15)]
        [Column(TypeName = "varchar(15)")]
        public string Rreal_Estate_Types_Name { get; set; }

        public IEnumerable<Subscription_File> subscription { get; set; }
    }
}   
