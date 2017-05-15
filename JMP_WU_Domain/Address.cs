using System;
using System.Collections.Generic;
using System.Text;

namespace JMP_WU_Domain
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

    }
}
