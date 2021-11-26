using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayxApp.Models.Juno
{
    public class Split
    {
        public string recipientToken { get; set; }
        public int amount { get; set; }
        public int percentage { get; set; }
        public bool amountRemainder { get; set; }
        public bool chargeFee { get; set; }
    }
}
