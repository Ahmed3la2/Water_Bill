using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace water_bill.Models
{
    public class Subscriber_File
    {
        [Key]
        [Required(ErrorMessage = "ادخل رقم الهويه")]
        [RegularExpression(@".{10}", ErrorMessage = " رقم الهويه يلزم 10 رقم")]
        [Column(TypeName = "char(10)")]
        [MaxLength(10)]
        public string Subscriber_File_Id { get; set; }

        [Required(ErrorMessage = "أدخل الاسم")]
        [Column(TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Subscriber_File_Name { get; set; }

        [Required(ErrorMessage = "ادخل المدينه")]
        [Column(TypeName = "varchar(50)")]
        [MaxLength(50)]
        public string Subscriber_File_City { get; set; }

        [Required(ErrorMessage = "ادخل الحي")]
        [Column(TypeName = "varchar(50)")]
        [MaxLength (50)]
        public string Subscriber_File_Area { get; set; }

        [Required(ErrorMessage = "اخل رقم الجوال")]
        [Column(TypeName = "varchar(20)")]
        [RegularExpression(@".{11}", ErrorMessage = " رقم الجوال يلزم 11 رقم")]

        public string Subscriber_File_Mobile  { get; set; }
        [Column(TypeName = "varchar(100)")]
        [MaxLength(100)]
 
        public string Subscriber_File_Reasons { get; set; }

        public IEnumerable<Subscription_File> Subscription { get; set; }

    }
}
