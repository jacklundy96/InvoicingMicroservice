using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using InvoicingMicroservice.DTOs;
using InvoicingMicroservice.Fakes;
using InvoicingMicroservice.Services;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace InvoicingMicroserviceTest
{
    public class InvoiceServiceTests
    {
        private readonly InvoiceService _iss;
        private readonly FakeDBService _fdbs;

        public InvoiceServiceTests()
        {
            _fdbs = new FakeDBService();
             _iss = new InvoiceService(new FakeCustomerDetailsService(), new HttpClient(), _fdbs);
        }

        [Fact]
        public async void SendInvoiceAsync_NullObjectCall()
        {
            //Arrange 
            Invoice invoice = null;
            //Act
            var result = await _iss.SendInvoiceAsync(invoice);
            //Assert 
            Assert.True(result.GetType() == typeof(BadRequestObjectResult));
        }

        [Fact]
        public async void SendInvoiceAsync_MissingDataCall()
        {
            new Invoice()
            {
                ID = 1,
                CustomerID = 3,
                OrderID = 4,
                ProductID = 5,
                ProductName = "Cleaner",
                Cost = "1",
                PaymentDateTime = new System.DateTime(2019, 12, 28, 10, 45, 30),
                hasInvoice = 0
            };

            //Arrange 
            Invoice invoice = null;
            //Act
            var result = await _iss.SendInvoiceAsync(invoice);
            //Assert 
            Assert.True(result.GetType() == typeof(BadRequestObjectResult));
        }

        [Fact]
        public async void SendInvoiceAsync_ValidCall()
        {
            new Invoice()
            {
                ID = 3,
                CustomerID = 3,
                OrderID = 4,
                ProductID = 5,
                ProductName = "Cleaner",
                Cost = "1",
                Quantity = 8,
                Total = "8",
                PaymentDateTime = new System.DateTime(2019, 3, 10, 2, 15, 10),
                hasInvoice = 0,
                PaidBy = new System.DateTime(2019, 3, 10, 2, 15, 10),
                InvoicedOn = new System.DateTime(2019, 3, 10, 2, 15, 10)
            };
            //Arrange 
            Invoice invoice = null;
            //Act
            var result = await _iss.SendInvoiceAsync(invoice);
            //Assert 
            Assert.True(result.GetType() == typeof(ObjectResult));
        }



    }
}
