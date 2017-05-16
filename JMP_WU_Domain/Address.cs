using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JMP_WU_Domain
{
    public class Address
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be between 2 and 50 letters.")]
        [RegularExpression(@"^[A-ZÅÄÖ]+[a-zåäöA-ZÅÄÖ0-9,.&:''-'\s]*$", ErrorMessage = "Must start with a Capital letter ex 'Karl' and not 'karl'. " +
           "And can only be chars between a-ö, 0-9, and chars ,.&:'-")]
        [Required]
        public string Street { get; set; }

        

        [RegularExpression(@"^\d{5}$", ErrorMessage = "Must be 5 digits")]
        [Required]
        public int ZipCode { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be between 2 and 50 letters.")]
        [RegularExpression(@"^[A-ZÅÄÖ]+[a-zåäöA-ZÅÄÖ''-'\s]*$", ErrorMessage = "Must start with a Capital letter ex 'Karl' and not 'karl'. " +
           "And can only be letter between a-ö.")]
        [Required]
        public string City { get; set; }

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

    }
}
