using PayxApp.Models;
using PayxApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PayxApp.Utilidades
{
    public static class Funcoes
    {
        public static List<DesmembramentoParcelasViewModel> GerarDesmembramentoParcelas(double valorPedido)
        {
            double valorParcelas = valorPedido / 12;
            List<DesmembramentoParcelasViewModel> listaDesmembramento = new List<DesmembramentoParcelasViewModel>();
            for (int i = 0; i < 12; i++)
            {
                listaDesmembramento.Add(new DesmembramentoParcelasViewModel() { NumeroParcela = i + 1, ValorParcela = Math.Round(valorParcelas + (valorParcelas * 0.25), 2) });
            }
            return listaDesmembramento;
        }

        public static string TransformarDataJuno(DateTime dataOriginal)
        {
            string ano = dataOriginal.Year.ToString(), mes = dataOriginal.Month.ToString(), dia = dataOriginal.Day.ToString();

            if (mes.Length == 1)
                mes = string.Concat("0", mes);

            if (dia.Length == 1)
                dia = string.Concat("0", dia);

            return string.Concat(ano, "-", mes, "-", dia);
        }

        public static DateTime TransformarDataJuno(string dataOriginal)
        {
            string[] dataQuebrada = dataOriginal.Split("-");
            return new DateTime(Convert.ToInt32(dataQuebrada[0]), Convert.ToInt32(dataQuebrada[1]), Convert.ToInt32(dataQuebrada[2]));
        }

        public static bool EnviarEmail(ContatoViewModel contato)
        {
            //Instancia um objeto da classe System.Net.Mail.SmtpClient e inicializa as credenciais
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("rvpayx@gmail.com", "Rvpayx47@");

            //Instancia uma mensagem de e-mail e inicializa seus campos
            MailMessage mail = new MailMessage();

            //Sender é quem vai enviar. From é o remetente. To.Add é o destinatário
            mail.Sender = new MailAddress(contato.EmailContato, contato.NomeContato);
            mail.From = new MailAddress(contato.EmailContato, contato.NomeContato);
            mail.To.Add(new MailAddress("rvpayx@gmail.com"));
            mail.Subject = string.Concat("[CONTATO SITE] - ", DateTime.Now);
            mail.Body = string.Concat("Nome: ", contato.NomeContato, "</br> E-mail: ", contato.EmailContato, "</br> Celular: ", contato.CelularContato, "</br> Mensagem: </br>", contato.MensagemContato);

            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            try
            {
                client.Send(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool EnviarEmailTokenConfirmacao(Usuario usuario, string linkConfirmacao)
        {
            //Instancia um objeto da classe System.Net.Mail.SmtpClient e inicializa as credenciais
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("rvpayx@gmail.com", "Rvpayx47@");
            //Instancia uma mensagem de e-mail e inicializa seus campos
            MailMessage mail = new MailMessage();

            //Sender é quem vai enviar. From é o remetente. To.Add é o destinatário
            mail.Sender = new MailAddress("rvpayx@gmail.com", "PayX Pagamentos");
            mail.From = new MailAddress("rvpayx@gmail.com", "PayX Pagamentos");
            mail.To.Add(new MailAddress(usuario.Email));
            mail.Subject = "Confirmação de E-mail [PAYX]";
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            string body = GerarBodyEmailConfirmacao(usuario, linkConfirmacao);
            mail.Body = body;

            try
            {
                client.Send(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string GerarBodyEmailConfirmacao(Usuario usuario, string link)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<html><head><meta charset='utf-8'><link rel='stylesheet' href='https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css' integrity='sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T' crossorigin='anonymous'></head>");
            sb.Append("<body><div class='container w-80 h-80 mx-auto p-5 shadow p-3 mb-5 bg-white rounded' style='word-wrap:break-word;'><img src='https://i.ibb.co/PGXF20m/logograndepayx.png' alt='Logo' width='48' style='display: block; width: 80px; max-width: 80px; min-width: 80px;' class='mx-auto'>");
            sb.Append("<h2 class='text-center'><strong>Confirme seu e-mail</strong></h2>");
            sb.Append(string.Concat("<p>Olá ", usuario.NomeCompleto, ", seja bem vindo à PayX! Clique no botão abaixo para confirmar seu endereço de e-mail. Se você não criou uma conta conosco, desconsidere esse e-mail.</p>"));
            sb.Append(string.Concat("<div class='col-md-12 text-center my-3'><a href='", link, "' class='btn btn-primary btn-lg align'>Confirmar</a></div><p style='text-overflow: ellipsis;'>Se o botão não funcionar, copie e cole o link no seu browser: </br>"));
            sb.Append(string.Concat("<u><small>", link, "</small></u></p><div class='col-md-12 text-right'><p>Atenciosamente,</br><strong>Equipe PayX</strong></p></div></div></body></html>"));

            return sb.ToString();
        }
    }
}
