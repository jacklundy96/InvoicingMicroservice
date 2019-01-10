using InvoicingMicroservice.DTOs;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace InvoicingMicroservice.Services
{

    public interface ICustomerService
    {
        Task<Customer> GetCustomerDetailsAsync(int CustomerID);
    }

    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _client;

        public CustomerService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Customer> GetCustomerDetailsAsync(int CustomerID)
        {
            HttpResponseMessage response = await _client.GetAsync("http://www.ThamcoCustomers.com/Customers/" + CustomerID);
            string responseBody = await response.Content.ReadAsStringAsync();
            Customer customer =  ParseJsonIntoCustomerAsync(responseBody);

            return new Customer();
        }

        private Customer ParseJsonIntoCustomerAsync(string responseBody)
        {
            Customer customer = new Customer()
            {
                CustomerID = (int)JObject.Parse(responseBody)["Id"],
                ContactForename = JObject.Parse(responseBody)["ContactForename"].ToString(),
                ContactSurname = JObject.Parse(responseBody)["ContactSurname"].ToString(),
                CustomerEmail = JObject.Parse(responseBody)["CustomerEmail"].ToString(),
                CustomerAddress = JObject.Parse(responseBody)["CustomerAddress"].ToString(),
            };
            return customer;
        }

    }
}
