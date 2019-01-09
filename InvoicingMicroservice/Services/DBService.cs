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

        List<Invoice> GetAllInvoices(int InvoiceID);

        void DeleteInvoices(int InvoiceID);
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
            return _context.Invoices.FirstOrDefault(i => i.OrderID == InvoiceID);
        }

        public List<Invoice> GetAllInvoices(int InvoiceID)
        {
            return _context.Invoices.Where(i => i.OrderID != -1).ToList();
        }

        public void DeleteInvoices(int InvoiceID)
        {
            var invoice = (Invoice)_context.Invoices.Where(i => i.ID == InvoiceID);
            _context.Invoices.Remove(invoice);
        }
    }
}
