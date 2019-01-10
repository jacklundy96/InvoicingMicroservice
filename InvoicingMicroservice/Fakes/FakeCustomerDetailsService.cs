using InvoicingMicroservice.DTOs;
using InvoicingMicroservice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoicingMicroservice.Fakes
{
    public class FakeCustomerDetailsService : ICustomerService
    {
        public async Task<Customer> GetCustomerDetailsAsync(int CustomerID)
        {
            List<Customer> customers = new List<Customer>()
            {
                new Customer()
                {
                    CustomerID = 1,
                    CustomerEmail = "MarkCorrigan@JLBCredit.com",
                    ContactForename = "Mark",
                    ContactSurname = "Corrigan",
                    CustomerAddress = "23 University Way",
                    CompanyName = "JLBCredit"
                },
                new Customer()
                {
                    CustomerID = 2,
                    CustomerEmail = "JeremyUsborne@BigBeatManifesto.com",
                    ContactForename = "Jeremy",
                    ContactSurname = "Usborne",
                    CustomerAddress = "23 University Way",
                    CompanyName = "JLBCredit"
                },
               new Customer()
                {
                    CustomerID = 3,
                    CustomerEmail = "SuperHans@BigBeatManifesto.com",
                    ContactForename = "Super",
                    ContactSurname = "Hans",
                    CustomerAddress = "The bag",
                    CompanyName = "Man Feelings"
                }
            };

            return customers.FirstOrDefault(c => c.CustomerID == CustomerID);

        }
    }
}
