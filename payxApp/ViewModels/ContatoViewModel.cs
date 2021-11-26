using System.ComponentModel.DataAnnotations;

namespace PayxApp.ViewModels
{
    public class ContatoViewModel
    {
        [Required(ErrorMessage = "Por favor, identifique-se")]
        [StringLength(300, ErrorMessage = "Limite de caracteres excedido")]
        [Display(Name = "Nome Completo")]
        public string NomeContato { get; set; }

        [Required(ErrorMessage = "Por favor, informe o seu e-mail.")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido!")]
        [Display(Name = "E-mail")]
        public string EmailContato { get; set; }

        [Required(ErrorMessage = "Por favor, informe um número para contato.")]
        [Display(Name = "Celular")]
        public string CelularContato { get; set; }

        [StringLength(700, MinimumLength = 15, ErrorMessage = "A mensagem deve conter entre 15 e 700 caracteres")]
        [Required(ErrorMessage = "Por favor, digite uma mensagem")]
        [Display(Name = "Mensagem")]
        public string MensagemContato { get; set; }
    }
}
