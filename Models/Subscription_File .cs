using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace water_bill.Models
{
    public class Subscription_File
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Number { get; set; }

        [Key]
        [Column(TypeName = "char(10)")]
        public string Subscription_File_No { get; set; }

        [Required(ErrorMessage = "ادخل رقم المشترك")]
        [RegularExpression(@".{10}", ErrorMessage = " رقم الهويه يلزم 10 حروف")]
        [Column(TypeName = "char(10)")]
        [MaxLength(10)]
        public string Subscription_File_Subscriber_CodeId { get; set; }
        public Subscriber_File Subscription_File_Subscriber_Code { get; set; }


        public string Subscription_File_Rreal_Estate_Types_CodeID  { get; set; }
        public Rreal_Estate_Types Subscription_File_Rreal_Estate_Types_Code { get; set; }

        [Required(ErrorMessage = "ادخل عدد الوحدات")]
        public int Subscription_File_Unit_No { get; set; }

        [Required(ErrorMessage = "هل يوجد صرف صحي")]
        public bool Subscription_File_Is_There_Sanitation { get; set; }

        public int Subscription_File_Last_Reading_Meter { get; set; }

        [MaxLength (100)]
        [Column(TypeName = "varchar(100)")]
        public string Subscription_File_Reasons { get; set; }



    }
}
