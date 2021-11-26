using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayxApp.Models.Juno
{
    public class Refund
    {
        public string id { get; set; }
        public string chargeId { get; set; }
        public string releaseDate { get; set; }
        public string paybackDate { get; set; }
        public double amount { get; set; }
        public double fee { get; set; }
        public string status { get; set; }
        public string transactionId { get; set; }
    }
}
