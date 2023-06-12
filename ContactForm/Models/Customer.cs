using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactForm.Models
{

    //Validation for entering at least one phone number
    public class AtLeastOnePhoneAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (string.IsNullOrEmpty(customer.HomePhone) &&
                string.IsNullOrEmpty(customer.WorkPhone) &&
                string.IsNullOrEmpty(customer.MobilePhone))
            {
                return new ValidationResult("You need to fill out at least one phone number.");
            }

            return ValidationResult.Success;
        }
    }


    public class Customer
    {
        [Key]
        public int Id { get; set; }

        //[DisplayName("Όνομα")]
        
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "No special characters allowed and you must enter a name with a capital letter first.")]
        [Required]
        public string Name { get; set; }

        //[DisplayName("Έπώνυμο")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "No special characters allowed and you must enter a Surname with a capital letter first.")]
        [Required]
        public string Surname { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        //[DisplayName("Τηλέφωνο Κατοικίας")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        [DataType(DataType.PhoneNumber)]
        [AtLeastOnePhone]
        public string? HomePhone { get; set; }

        //[DisplayName("Κινητό τηλέφωνο")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        [DataType(DataType.PhoneNumber)]
        [AtLeastOnePhone]
        public string? MobilePhone { get; set; }

        //[DisplayName("Τηλέφωνο Εργασίας")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        [DataType(DataType.PhoneNumber)]
        [AtLeastOnePhone]
        public string? WorkPhone { get; set; }
    }
}
