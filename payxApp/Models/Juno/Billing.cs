using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayxApp.Models.Juno
{
    public class Billing
    {
        public string name { get; set; }
        public string document { get; set; }
        public string email { get; set; }
        public string secondaryEmail { get; set; }
        public string phone { get; set; }
        public string birthDate { get; set; }
        public bool notify { get; set; }
    }
}
