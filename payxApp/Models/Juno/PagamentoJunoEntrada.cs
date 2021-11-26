using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayxApp.Models.Juno
{
    public class PagamentoJunoEntrada
    {
        public string chargeId { get; set; }
        public BillingPagamento billing { get; set; }
        public CreditCardDetails creditCardDetails { get; set; }
    }
}