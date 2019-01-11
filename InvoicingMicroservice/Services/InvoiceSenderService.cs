using InvoicingMicroservice.DTOs;
using Microsoft.AspNetCore.Hosting;
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
            _cs =  cs;
        }
        public async Task<IActionResult> SendInvoiceAsync(Invoice invoice)
        {
           Customer customer = await _cs.GetCustomerDetailsAsync(invoice.CustomerID);

            string InvoiceContent =
                $"ThamCo Invoice\n{customer.CompanyName}\n InvoiceNumber: {invoice.ID}\nInvoice Date: {DateTime.Now}\nInvoice Due Date: {invoice.PaidBy}\n" +
                $"{invoice.Quantity} x {invoice.ProductName} @ {invoice.Cost} = {invoice.Total}";

            SendEmail(customer.CustomerEmail, "ThamCo Order: ", InvoiceContent);
            return new OkResult();
        }

        private async Task SendEmail(string email, string subject, string htmlContent)
        {
            var apiKey = "";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("Invoicing@ThamCo.co.uk", "Admin");
            var to = new EmailAddress(email);
            var plainTextContent = Regex.Replace(htmlContent, "<[^>]*>", "");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
