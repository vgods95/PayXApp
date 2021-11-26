using PayxApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayxApp.ViewModels
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "Por favor, informe o seu CPF")]
        [StringLength(30, ErrorMessage = "Limite de caracteres excedido")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Por favor, identifique-se")]
        [StringLength(300, ErrorMessage = "Limite de caracteres excedido")]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o seu CEP")]
        [StringLength(10, ErrorMessage = "Limite de caracteres excedido")]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Por favor, informe o seu endereço")]
        [StringLength(200, ErrorMessage = "Limite de caracteres excedido")]
        [Display(Name = "Endereço")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Por favor, informe o número.")]
        [StringLength(10, ErrorMessage = "Limite de caracteres excedido")]
        [Display(Name = "Número")]
        public string Numero { get; set; }

        [StringLength(100, ErrorMessage = "Limite de caracteres excedido")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Por favor, informe o bairro.")]
        [StringLength(100, ErrorMessage = "Limite de caracteres excedido")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Por favor, selecione uma cidade.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Por favor, informe um número para contato.")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Por favor, informe a sua data de nascimento.")]
        [Display(Name = "Data de Nascimento")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "Por favor, selecione um sexo.")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Por favor, informe o seu e-mail.")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido!")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, digite uma senha")]
        [StringLength(40, ErrorMessage = "A senha deve ter NO MÁXIMO 40 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Por favor, confirme a sua senha")]
        [StringLength(40, ErrorMessage = "A senha deve ter NO MÁXIMO 40 caracteres")]
        [Display(Name = "Confirme sua senha")]
        [Compare("Senha", ErrorMessage = "As senhas não conferem")]
        [DataType(DataType.Password)]
        public string SenhaConfirmada { get; set; }

    }
}
