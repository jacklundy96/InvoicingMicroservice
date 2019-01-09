using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InvoicingMicroservice.DB;
using InvoicingMicroservice.DTOs;

namespace InvoicingMicroservice.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly InvoiceContext _context;

        public InvoicesController(InvoiceContext context)
        {
            _context = context;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            var Invoices = await _context.Invoices.ToListAsync();
            //Get Customer Information
            Invoices.Where(i => i.hasInvoice == 0);

            return View(Invoices.Where(i => i.hasInvoice == 0));
        }

        public async Task<IActionResult> SendInvoice(int id)
        {
            return View(await _context.Invoices.ToListAsync());
        }      
    }
}
