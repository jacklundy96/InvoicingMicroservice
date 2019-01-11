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
        private readonly IDBService _dbs;
        private readonly IInvoiceService _iss;

        public InvoicesController(IInvoiceService iss,IDBService dbs)
        {
            _dbs = dbs;
            _iss = iss;
        }

        public IActionResult Index()
        {
            var Invoices = _dbs.GetAllInvoices();
            Invoices.Where(i => i.hasInvoice == 0);
            return View(Invoices.Where(i => i.hasInvoice == 0));
        }

        public async Task<IActionResult> SendInvoice(int id)
        {          
            _iss.SendInvoiceAsync(_dbs.GetInvoice(id));
            _dbs.UpdateInvoicedStatus(id);
            return RedirectToAction("Index");
        }      
    }
}
