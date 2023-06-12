using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactForm.Models
{
    public class PhoneContact
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("PersondetsId")]
        public int? CustomerId { get; set; }
        
        public virtual Customer Customer { get; set; }

        [StringLength(10, MinimumLength = 10)]
        [DataType(DataType.PhoneNumber)]
        public string? MobilePhone { get; set; }

        [StringLength(10, MinimumLength = 10)]
        [DataType(DataType.PhoneNumber)]
        public string? WorkPhone { get; set; }

        [StringLength(10, MinimumLength = 10)]
        [DataType(DataType.PhoneNumber)]
        public string? HomePhone { get; set; }

        
    }
}
