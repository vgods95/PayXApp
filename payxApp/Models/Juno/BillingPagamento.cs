using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayxApp.Models.Juno
{
    public class BillingPagamento
    {
        public string email { get; set; }
        public Address address { get; set; }
        public bool delayed { get; set; }
    }
}
