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
        private readonly InvoiceContext _context;
         {
        private readonly InvoiceSenderService _iss;

        public InvoicesController(InvoiceContext context,InvoiceSenderService iss)
        {
            _iss = iss;
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


            SendInvoice()

            return View(await _context.Invoices.ToListAsync());
        }      
    }
}
