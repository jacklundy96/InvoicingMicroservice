using InvoicingMicroservice.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoicingMicroservice
{
    public class DBInitializer
    {
        public static void Initialize(InvoiceContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
