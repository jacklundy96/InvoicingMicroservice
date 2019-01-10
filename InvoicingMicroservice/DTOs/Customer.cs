using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoicingMicroservice.DTOs
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerAddress { get; set;  }

        public string CompanyName { get; set; }

        public string ContactForename { get; set; }

        public string ContactSurname { get; set; }
    }
}
