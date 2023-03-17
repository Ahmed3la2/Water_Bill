using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Water_Bill.ViewModel
{
    public class SubscribtionVM
    {

        [Column(TypeName = "char(10)")]
      
        public string Subscription_File_No { get; set; }

        [Required(ErrorMessage = "ادخل رقم المشترك")]
        [RegularExpression(@".{10}", ErrorMessage = " رقم الهويه يلزم 10 حروف")]
        [MaxLength(10)]
        public string Subscription_File_Subscriber_CodeId { get; set; }

        [Required(ErrorMessage = "أدخل الاسم")]
        [MaxLength(100)]
        public string Subscriber_File_Name { get; set; }

        [Required(ErrorMessage = "ادخل المدينه")]
        [MaxLength(50)]
        public string Subscriber_File_City { get; set; }

        [Required(ErrorMessage = "ادخل الحي")]
        [MaxLength(50)]
        public string Subscriber_File_Area { get; set; }

        [Required(ErrorMessage = "ادخل رقم الجوال")]
        [MaxLength(13)]
        public string Subscriber_File_Mobile { get; set; }

        [Required(ErrorMessage = "ادخل عدد الوحدات")]
        public int Subscription_File_Unit_No { get; set; }

        [Required(ErrorMessage = "هل يوجد صرف صحي")]
        public bool Subscription_File_Is_There_Sanitation { get; set; }

        public string Subscription_File_Rreal_Estate_Types_CodeID { get; set; }
    }
}
