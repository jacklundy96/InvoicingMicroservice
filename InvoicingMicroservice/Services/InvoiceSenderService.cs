using InvoicingMicroservice.DTOs;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InvoicingMicroservice.Services
{
    public interface IInvoiceSenderService
    {
        IActionResult SendInvoice(Invoice invoice);
        Task SendEmail(string email, string subject, string htmlContent);
    }

    public class InvoiceSenderService
    {

        private ICustomerService _cs;

        public InvoiceSenderService(ICustomerService cs)
        {
            _cs = cs;
        }
        public IActionResult SendInvoice(Invoice invoice)
        {
            //TODO::Get customer info from another service

            SendEmail("jacklundy@hotmail.co.uk", "ThamCo Order: ", "Your recent order with ThamCo");
            return new OkResult();
        }

        private async Task SendEmail(string email, string subject, string htmlContent)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("Invoicing@ThamCo.co.uk", "Admin");
            var to = new EmailAddress(email);
            var plainTextContent = Regex.Replace(htmlContent, "<[^>]*>", "");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
