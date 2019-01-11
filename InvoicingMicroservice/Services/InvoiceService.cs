using InvoicingMicroservice.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InvoicingMicroservice.Services
{
    public interface IInvoiceService
    {
        Task<IActionResult> SendInvoiceAsync(Invoice invoice);
        Task<IActionResult> SendEmail(string email, string subject, string htmlContent);
    }

    public class InvoiceService : IInvoiceService
    {
        private readonly IDBService _dbs;
        private readonly ICustomerService _cs;
        private readonly HttpClient _client;

        public InvoiceService(ICustomerService cs,HttpClient client,IDBService dbs)
        {
            _client = client;
            _cs =  cs;
            _dbs = dbs;
        }
        public async Task<IActionResult> SendInvoiceAsync(Invoice invoice)
        {
           if (invoice == null)
               return new BadRequestObjectResult(new {Message = "Invoice object is null or missing information" }); 

           Customer customer = await _cs.GetCustomerDetailsAsync(invoice.CustomerID);
           if (customer == null)
               return new NotFoundObjectResult(new { Message = "Invoice object is null or missing information" });

            string InvoiceContent =
                $"ThamCo Invoice\n{customer.CompanyName}\n InvoiceNumber: {invoice.ID}\nInvoice Date: {DateTime.Now}\nInvoice Due Date: {invoice.PaidBy}\n" +
                $"{invoice.Quantity} x {invoice.ProductName} @ {invoice.Cost} = {invoice.Total}";

            return await SendEmail(customer.CustomerEmail, "ThamCo Order: ", InvoiceContent);
        }

        private async Task<IActionResult> SendEmail(string email, string subject, string htmlContent)
        {
            //TODO ::Embed in application in keystore
            var apiKey = "";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("Invoicing@ThamCo.co.uk", "Admin");
            var to = new EmailAddress(email);
            var plainTextContent = Regex.Replace(htmlContent, "<[^>]*>", "");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response =  await client.SendEmailAsync(msg);

            if(response.StatusCode == HttpStatusCode.Accepted)
                return new OkResult();
            else 
                return new ObjectResult(new {Message = "Invoice failed to send"});
        }

        public async void GetInvoicesAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("http://www.ThamcoCustomers.com/Payments/GetAll");

            var Invoices = await response.Content.ReadAsAsync<IEnumerable<Invoice>>().ToAsyncEnumerable().ToList();
            List<Invoice> CurrentInvoices = _dbs.GetAllInvoices();

            foreach (Invoice inv in CurrentInvoices)
                CurrentInvoices = CurrentInvoices.Where(x => !x.PaymentDateTime.Equals(inv.PaymentDateTime) && x.OrderID == inv.OrderID).ToList();

            foreach (Invoice inv in CurrentInvoices)
                _dbs.SaveInvoice(inv);
        }

        Task<IActionResult> IInvoiceService.SendEmail(string email, string subject, string htmlContent)
        {
            throw new NotImplementedException();
        }
    }
}
