using InvoicingMicroservice.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using InvoicingMicroservice.Services;
using Xunit;
using System.Net.Http;

namespace InvoicingMicroserviceTest
{
    public class CustomerServiceTest
    {

        private readonly CustomerService _cs;

        public CustomerServiceTest()
        {
            _cs = new CustomerService(new HttpClient());
        }

        [Fact]
        public async void SendInvoiceAsync_ValidCall()
        {
            //Arrange 
            int index = 1;
            //Act
            var result = await _cs.GetCustomerDetailsAsync(index);
            //Assert 
            Assert.True(result.GetType() == typeof(Customer) && result != null);
        }

        [Fact]
        public async void GetCustomerDetailsAsync_OutOfBoundsIndex()
        {
            //Arrange 
            int index = -1;
            //Act
            var result = await _cs.GetCustomerDetailsAsync(index);
            //Assert 
            Assert.Null(result);
        }
    }
}
