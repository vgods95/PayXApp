using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayxApp.Models
{
    public class Usuario : IdentityUser<string>
    {
        public string Cpf { get; set; }
        public string NomeCompleto { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public int CidadeId { get; set; }

        [NotMapped]
        public virtual Cidade Cidade { get; set; }

        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }

        [NotMapped]
        public virtual IEnumerable<Conta> Contas { get; set; }

        [NotMapped]
        public virtual IEnumerable<Boleto> Boletos { get; set; }

        [NotMapped]
        public virtual IEnumerable<Transacao> Transacoes { get; set; }

        [NotMapped]
        public virtual IEnumerable<Transacao> TransacoesAprovadasReprovadas { get; set; }

        [NotMapped]
        public virtual IEnumerable<CartaoCredito> Cartoes { get; set; }
    }
}
