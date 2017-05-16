using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JMP_WU_Domain
{
    public class PhoneNr
    {
        public int Id { get; set; }

        [RegularExpression(@"^[0-9-]+$", ErrorMessage = "Can only be numbers and ' - '")]
        [Required]
        public string MainPhoneNr { get; set; }

        [RegularExpression(@"^[0-9-]+$", ErrorMessage = "Can only be numbers and ' - '")]
        
        public string AltPhoneNr1 { get; set; }

        [RegularExpression(@"^[0-9-]+$", ErrorMessage = "Can only be numbers and ' - '")]
        
        public string AltPhoneNr2 { get; set; }

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }


    }
}
