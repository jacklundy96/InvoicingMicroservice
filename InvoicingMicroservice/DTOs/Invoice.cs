using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InvoicingMicroservice.DTOs
{
    public class Invoice
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Cost { get; set; }
        public int Quantity { get; set; }
        public string Total { get; set; }
        public DateTime PaymentDateTime { get; set; }
        public int hasInvoice {get; set;}
        public DateTime InvoicedOn { get; set; }
        public DateTime PaidBy { get; set; }

    }
}
