using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoicingMicroservice.DTOs;
using InvoicingMicroservice.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvoicingMicroservice.Fakes
{
    public class FakeInvoiceService : IInvoiceService
    {
        public async Task<IActionResult> SendInvoiceAsync(Invoice invoice)
        {
            return new OkResult();
        }

        public async Task<IActionResult> SendEmail(string email, string subject, string htmlContent)
        {
            return new OkResult();
        }
    }
}
