using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InvoicingMicroservice.DB;
using InvoicingMicroservice.DTOs;
using InvoicingMicroservice.Services;

namespace InvoicingMicroservice.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly DBService _context;
         
        private readonly InvoiceSenderService _iss;

        public InvoicesController(DBService context,InvoiceSenderService iss)
        {
            _iss = iss;
            _context = context;
        }

        public IActionResult Index()
        {
            var Invoices = _context.GetAllInvoices();
            Invoices.Where(i => i.hasInvoice == 0);
            return View(Invoices.Where(i => i.hasInvoice == 0));
        }

        public async Task<IActionResult> SendInvoice(int id)
        {          
            _iss.SendInvoiceAsync(_context.GetInvoice(id));
            _context.UpdateInvoicedStatus(id);
            return RedirectToAction("Index");
        }      
    }
}
