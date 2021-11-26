using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PayxApp.ViewModels
{
    public class SimulacaoViewModel
    {
        [Required(ErrorMessage = "Por favor, identifique-se")]
        [StringLength(300, ErrorMessage = "Limite de caracteres excedido")]
        [Display(Name = "Nome Completo")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "Por favor, informe o seu e-mail.")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido!")]
        [Display(Name = "E-mail")]
        [StringLength(150, ErrorMessage = "Limite de caracteres excedido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe um número para contato.")]
        [StringLength(20, ErrorMessage = "Limite de caracteres excedido")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Por favor, informe o valor desejado.")]
        public string Valor { get; set; }

        [Required(ErrorMessage = "Por favor, selecione a quantidade de parcelas.")]
        public string Parcelas { get; set; }

        public List<DesmembramentoParcelasViewModel> listaParcelas { get; set; }
    }
}
