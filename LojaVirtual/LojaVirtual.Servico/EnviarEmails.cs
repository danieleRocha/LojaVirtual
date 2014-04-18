using System;
using System.Net;
using System.Net.Mail;
using LojaVirtual.Modelo;

namespace LojaVirtual.Servico
{
    public static class EnviarEmails
    {
        public static bool Enviar(Usuario usuario)
        {
            var client = ObterCliente();
            bool mensagensEnviadasComSucesso = true;
            
            var email = CriarMensagem(usuario);

            try
            {
                client.Send(email);
            }
            catch (Exception e)
            {
                mensagensEnviadasComSucesso = false;
            }
            
            var emailAdministrador = CriarMensagemAdminstrador(usuario);

            try
            {
                client.Send(emailAdministrador);
            }
            catch (Exception e)
            {
                mensagensEnviadasComSucesso = false;
            }

            return mensagensEnviadasComSucesso;
        }

        private static MailMessage CriarMensagemAdminstrador(Usuario usuario)
        {
            string tratamento = "Prezado ";

            tratamento += "Administrador";

            var email = new MailMessage()
            {
                From = new MailAddress("avaliacaoonlineinfnet@gmail.com", "Loja Virtual"),
                Subject = "Solicitação de recuperação de senha",
                Body = tratamento + ", \n\n" +
                "O seguinte usuário solicitou a recuperação de senha: \n\n" +
                       "E-mail: " + usuario.Email + "\n\n" +
                       "Por favor não responda. Essa é uma mensagem automática.",
                IsBodyHtml = false,
                Priority = MailPriority.High,

            };
            email.To.Add("avaliacaoonlineinfnet@gmail.com");
            return email;
        }

        private static MailMessage CriarMensagem(Usuario usuario)
        {
            string tratamento = "Prezado ";
            if (usuario.Sexo == Usuario.Sexos.Femenino) tratamento = "Prezada ";

            tratamento += usuario.Nome;

            var email = new MailMessage()
                {
                    From = new MailAddress("avaliacaoonlineinfnet@gmail.com", "Loja Virtual"),
                    Subject = "Dados de acesso à Loja Virtual",
                    Body = tratamento + ", \n\n" +
                    "Seus dados de acesso são: \n\n" +
                           "E-mail: "+usuario.Email + "\n\n" +
                           "Senha: " + usuario.Senha + " \n\n" +
                           "Por favor não responda. Essa é uma mensagem automática.",
                    IsBodyHtml = false,
                    Priority = MailPriority.High,

                };
            email.To.Add(usuario.Email);
            return email;
        }

        private static SmtpClient ObterCliente()
        {
            var client = new SmtpClient()
                 {
                     Host = "smtp.gmail.com",
                     EnableSsl = true,
                     Credentials = new NetworkCredential("avaliacaoonlineinfnet", "avaliacaoonline"),
                     Port = 587
                 };
            return client;
        }

    }
}
