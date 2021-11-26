using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayxApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Por favor, informe o seu CPF")]
        [StringLength(30, ErrorMessage = "Limite de caracteres excedido")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Por favor, informe a sua senha")]
        [StringLength(40, ErrorMessage = "A senha deve ter NO MÁXIMO 40 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
