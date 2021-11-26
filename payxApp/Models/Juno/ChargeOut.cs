using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayxApp.Models.Juno
{
    public class ChargeOut
    {
        public string id { get; set; }
        public int code { get; set; }
        public string reference { get; set; }

        public string link { get; set; }
        public string checkoutUrl { get; set; }
        public string installmentLink { get; set; }
        public string payNumber { get; set; }

        public string status { get; set; }
        public BilletDetails billetDetails { get; set; }
        public Links _links { get; set; }

        public string dueDate { get; set; }
        public double amount { get; set; }
        public List<Payment> payments { get; set; }
    }
}
