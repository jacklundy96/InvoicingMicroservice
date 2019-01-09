using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace InvoicingMicroservice.Services
{
    public class CustomerDetailsService
    {
        private readonly HttpClient _client;

        public CustomerDetailsService(HttpClient client)
        {
            _client = client;
        }

    }
}
