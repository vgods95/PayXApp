using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayxApp.Models.Juno
{
    public class BilletDetails
    {
        public string bankAccount { get; set; }
        public string ourNumber { get; set; }
        public string barcodeNumber { get; set; }
        public string portfolio { get; set; }
    }
}
