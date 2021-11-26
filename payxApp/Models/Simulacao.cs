using System;

namespace PayxApp.Models
{
    public class Simulacao
    {
        public int Id { get; set; }

        public string NomeCompleto { get; set; }

        public string Email { get; set; }

        public string Celular { get; set; }

        public double Valor { get; set; }

        public int Parcelas { get; set; }
        public DateTime DataHora { get; set; }
        public string DesmembramentoParcelasJson { get; set; }

    }
}
