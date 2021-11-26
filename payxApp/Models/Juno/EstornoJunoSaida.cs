using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayxApp.Models.Juno
{
    public class EstornoJunoSaida
    {
        public string transactionId { get; set; }
        public int installments { get; set; }
        public List<Payment> payments { get; set; }
        public List<Refund> refunds { get; set; }
    }
}
