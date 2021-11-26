using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayxApp.Models.Juno
{
    public class Charge
    {
        public string pixKey { get; set; }
        public string description { get; set; }
        public List<string> references { get; set; }
        public double totalAmount { get; set; }
        //public double amount { get; set; }
        public string dueDate { get; set; }
        public int installments { get; set; }
        public int maxOverdueDays { get; set; }
        public int fine { get; set; }
        public string interest { get; set; }
        public string discountAmount { get; set; }
        public int discountDays { get; set; }
        public List<string> paymentTypes { get; set; }
        public bool paymentAdvance { get; set; }
        public string feeSchemaToken { get; set; }
        public List<Split> split { get; set; }
    }
}
