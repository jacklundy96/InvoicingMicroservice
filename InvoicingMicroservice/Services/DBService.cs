using InvoicingMicroservice.DB;
using InvoicingMicroservice.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoicingMicroservice.Services
{
    public interface IDBService
    {
        void SaveInvoice(Invoice invoice);

        Invoice GetInvoice(int InvoiceID);

        List<Invoice> GetAllInvoices();

        void DeleteInvoice(int InvoiceID);

        void UpdateInvoicedStatus(int InvoiceID);
    }

    public class DBService : IDBService
    {
        private readonly InvoiceContext _context;

        public DBService(InvoiceContext context)
        {
            _context = context;
        }

        public void SaveInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
        }

        public Invoice GetInvoice(int InvoiceID)
        {
            return _context.Invoices.FirstOrDefault(i => i.ID == InvoiceID);
        }

        public List<Invoice> GetAllInvoices()
        {
            return _context.Invoices.Where(i => i.OrderID != -1).ToList();
        }

        public void DeleteInvoice(int InvoiceID)
        {
            var invoice = _context.Invoices.FirstOrDefault(i => i.ID == InvoiceID);
            _context.Invoices.Remove(invoice);
        }

        public void UpdateInvoicedStatus(int InvoiceID)
        {
            var invoice = GetInvoice(InvoiceID);
            Invoice i = new Invoice()
            {
                CustomerID = invoice.CustomerID,
                OrderID = invoice.OrderID,
                ProductID = invoice.ProductID,
                ProductName = invoice.ProductName,
                Cost = invoice.Cost,
                Quantity = invoice.Quantity,
                Total = invoice.Total,
                PaymentDateTime = invoice.PaymentDateTime,
                InvoicedOn = DateTime.Now,
                PaidBy = DateTime.Now.AddDays(30),
                hasInvoice = 1
            };
            DeleteInvoice(InvoiceID);
            SaveInvoice(i);
        }
    }
}
