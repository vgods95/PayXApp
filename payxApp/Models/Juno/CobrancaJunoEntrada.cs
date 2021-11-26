using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayxApp.Models.Juno
{
    public class CobrancaJunoEntrada
    {
        public Charge charge { get; set; }
        public Billing billing { get; set; }
    }
}
