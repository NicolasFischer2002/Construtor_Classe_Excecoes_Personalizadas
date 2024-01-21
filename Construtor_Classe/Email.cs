using System.Net.Mail;
using System.Runtime.CompilerServices;


namespace Construtor_Classe
{
    public enum SetorUsuario
    {
        Administrativo,
        Financeiro,
        Suporte,
        TI
    }

    public partial class Email
    {
        public readonly string NomeUsuario;
        public string EnderecoEmail { get; set; }
        public readonly string Senha;
        public readonly string EmailRecuperacao;
        public bool AutenticacaoDoisFatoresAtiva { get; set; } = false;
        public SetorUsuario SetorUsuario;
        public bool ContaBloqueada { get; set; } = false;
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public Email(string nomeUsuario, string enderecoEmail, string senha, string emailRecuperacao,
            bool autenticacaoDoisFatoresAtiva, SetorUsuario setor)
        {
            ValidaNomeUsuario(nomeUsuario);

            ValidaEmail(enderecoEmail);

            ValidaEmailRecuperacao(emailRecuperacao, enderecoEmail);

            if (!ExpressaoRegular.SenhaValida(senha.Trim()))
                throw new SenhaInvalidaException("A senha informada não atende aos critérios! " +
                    "Deve ter 8 caracteres ou mais, conter um número e conter um caractere especial.");

            NomeUsuario = nomeUsuario.Trim();
            EnderecoEmail = enderecoEmail.Trim().ToLower();
            Senha = Criptografia.CalcularHashMD5(senha.Trim());
            EmailRecuperacao = emailRecuperacao.Trim().ToLower();
            AutenticacaoDoisFatoresAtiva = autenticacaoDoisFatoresAtiva;
            SetorUsuario = setor;
        }

        private static void ValidaNomeUsuario(string nomeUsuario)
        {
            if (!string.IsNullOrEmpty(nomeUsuario))
            {
                if (!ExpressaoRegular.ContemApenasLetrasEspacos(nomeUsuario))
                    throw new NomeUsuarioInvalidoException("Nome inválido! são permitidos apenas letras e espaços.");

                if (nomeUsuario.Length < 2)
                    throw new NomeUsuarioInvalidoException("Nome muito curto! Nome deve ter pelo menos 2 caracteres.");

                if (nomeUsuario.Length > 60)
                    throw new NomeUsuarioInvalidoException("Nome muito longo! Nome deve ter no máximo 60 caracteres.");
            }
            else
                throw new NomeUsuarioInvalidoException("Nome não pode ser nulo ou vazio!");
        }

        private static void ValidaEmail(string email)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    MailAddress mailAddress = new(email);
                }
                else
                    throw new EmailInvalidoException("E-mail não pode ser nulo ou vazio!");
            }
            catch (FormatException)
            {
                throw new EmailInvalidoException("E-mail em um formato inválido!");
            }
        }

        private static void ValidaEmailRecuperacao(string emailRecuperacao, string email)
        {
            try
            {
                if (!string.IsNullOrEmpty(emailRecuperacao))
                {
                    if (emailRecuperacao != email)
                    {
                        MailAddress mailAddress = new(emailRecuperacao);
                    } else
                        throw new EmailRecuperacaoInvalidoException("O e-mail não pode ser igual ao e-mail de recuperação!");
                }
                else
                    throw new EmailRecuperacaoInvalidoException("E-mail de recuperação não pode ser nulo ou vazio!");
            }
            catch (FormatException)
            {
                throw new EmailRecuperacaoInvalidoException("E-mail de recuperação em um formato inválido!");
            }
        }
    }
}
