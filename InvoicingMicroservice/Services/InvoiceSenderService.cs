using FluentEmail.Core;
using InvoicingMicroservice.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoicingMicroservice.Services
{
    public class InvoiceSenderService
    {
        public IActionResult SendInvoice(Invoice invoice)
        {
            var template = "Dear @Model.Name, You are totally @Model.Compliment.";

            var email = Email
                .From("jacklundy@hotmail.co.uk")
                .To("josephhindmarsh96@gmail.com")
                .Subject("woo nuget")
                .UsingTemplate(template, new { Name = "Luke", Compliment = "Awesome" });


            return new OkResult();
        }

    }
}
