using System;
using System.Collections.Generic;
using System.Text;

namespace JMP_WU_Domain
{
    public class PhoneNr
    {
        public int Id { get; set; }
        public string MainPhoneNr { get; set; }
        public string AltPhoneNr1 { get; set; }
        public string AltPhoneNr2 { get; set; }

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }


    }
}
