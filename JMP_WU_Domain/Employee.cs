using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JMP_WU_Domain
{
    public class Employee
    {
        public int Id { get; set; }

        [StringLength(25, MinimumLength = 2, ErrorMessage = "Must be between 2 and 25 letters.")]
        [RegularExpression(@"^[A-ZÅÄÖ]+[a-zåäöA-ZÅÄÖ''-'\s]*$", ErrorMessage = "Must start with a Capital letter ex 'Karl' and not 'karl'. " +
            "And can only be letter between a-ö.")]
        [Required]
        public string FirstName { get; set; }

        [StringLength(25, MinimumLength = 2, ErrorMessage = "Must be between 2 and 25 letters.")]
        [RegularExpression(@"^[A-ZÅÄÖ]+[a-zåäöA-ZÅÄÖ''-'\s]*$", ErrorMessage = "Must start with a Capital letter ex 'Karl' and not 'karl'. " + 
           "And can only be letter between a-ö.")]
        [Required]
        public string LastName { get; set; }


        //[RegularExpression(@"^\d{4}-((0[1-9])|(1[012]))-((0[1-9]|[12]\d)|3[01])$", ErrorMessage = "Bust be in format ex. 1985-11-24")]
        [DataType(DataType.Date, ErrorMessage = "This is not a valid date format. Pls enter in this format ex.  1973-02-31 ")]
        [Required]
        
        public DateTime DateOfBirth { get; set; }

        //[RegularExpression(@"^\d{4}-((0[1-9])|(1[012]))-((0[1-9]|[12]\d)|3[01])$", ErrorMessage = "Bust be in format ex. 1985-11-24")]
        [Required]
        [DataType(DataType.Date, ErrorMessage = "This is not a valid date format. Pls enter in this format ex. 1973-02-31 ")]
        public DateTime EmployedSince { get; set; }

        public virtual PhoneNr PhoneNr { get; set; }
        public virtual Address Address { get; set; }
        public virtual Salary Salary { get; set; }

        public virtual ICollection<EmployeeProjects> EmployeeProjects { get; set; }



    }
}
