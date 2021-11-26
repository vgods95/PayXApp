using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayxApp.Models.Juno
{
    public class Address
    {
        public string street { get; set; }
        public string number { get; set; }
        public string complement { get; set; } //não requerido
        public string neighborhood { get; set; } //bairro - não requerido
        public string city { get; set; }
        public string state { get; set; }
        public string postCode { get; set; }
    }
}
