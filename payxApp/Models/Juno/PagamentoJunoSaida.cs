using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayxApp.Models.Juno
{
    public class PagamentoJunoSaida
    {
        public string transactionId { get; set; }
        public int installments { get; set; }
        public List<Payment> payments { get; set; }
    }
}
