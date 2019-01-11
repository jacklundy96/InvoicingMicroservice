using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using InvoicingMicroservice.DTOs;
using InvoicingMicroservice.Services;

namespace InvoicingMicroservice.Fakes
{
    public class FakeDBService : IDBService
    {
        private readonly List<Invoice> Invoices;

        public FakeDBService()
        {
            Invoices = new List<Invoice>()
            {
                new Invoice()
                {
                    ID = 1,
                    CustomerID= 3,
                    OrderID = 4,
                    ProductID = 5,
                    ProductName = "Cleaner",
                    Cost = "1", 
                    Quantity = 8,
                    Total = "8",
                    PaymentDateTime =new System.DateTime(2019, 12, 28, 10, 45, 30) ,
                    hasInvoice = 0
                },
                new Invoice()
                {
                    ID = 2,
                    CustomerID= 3,
                    OrderID = 4,
                    ProductID = 5,
                    ProductName = "Cleaner",
                    Cost = "1",
                    Quantity = 8,
                    Total = "8",
                    PaymentDateTime = new System.DateTime(2019, 7, 15, 6, 30, 20),
                    hasInvoice = 0
                },
                new Invoice()
                {
                    ID = 3,
                    CustomerID= 3,
                    OrderID = 4,
                    ProductID = 5,
                    ProductName = "Cleaner",
                    Cost = "1",
                    Quantity = 8,
                    Total = "8",
                    PaymentDateTime = new System.DateTime(2019, 3, 10, 2, 15, 10),
                    hasInvoice = 0
                }
            };
        }

        public void DeleteInvoice(int InvoiceID)
        {
        }

        public List<Invoice> GetAllInvoices()
        {
            return Invoices;
        }

        public Invoice GetInvoice(int InvoiceID)
        {
            if (Invoices.Count <= InvoiceID)
                return Invoices[InvoiceID];
            else
                return null;
        }

        public void SaveInvoice(Invoice invoice)
        {
        }

        public void UpdateInvoicedStatus(int InvoiceID)
        {
        }
    }
}
