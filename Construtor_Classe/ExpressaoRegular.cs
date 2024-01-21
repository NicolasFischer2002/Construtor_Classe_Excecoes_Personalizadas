using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Construtor_Classe
{
    public partial class ExpressaoRegular
    {
        public static bool ContemApenasLetrasEspacos(string input)
        {
            Regex regex = MyRegexApenasLetrasEspacos();
            return regex.IsMatch(input);
        }

        // Usando uma expressão regular para verificar se a string contém apenas letras e espaços
        // A expressão regular ^[a-zA-Z ]+$ corresponde a uma string que contém apenas letras (maiúsculas e minúsculas) e espaços.
        [GeneratedRegex("^[a-zA-Z ]+$")]
        private static partial Regex MyRegexApenasLetrasEspacos();

        public static bool SenhaValida(string senha)
        {
            if (!string.IsNullOrEmpty(senha))
            {
                // A expressão regular ^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$
                // faz a validação desejada:
                // ^                  - Início da string
                // (?=.*[A-Za-z])     - Pelo menos uma letra
                // (?=.*\d)           - Pelo menos um dígito
                // (?=.*[@$!%*?&])    - Pelo menos um caractere especial
                // [A-Za-z\d@$!%*?&]{8,} - 8 ou mais caracteres, permitindo letras, dígitos e caracteres especiais
                // $                  - Fim da string
                Regex regex = MyRegexSenhaValida();

                // Verifica se a senha atende aos critérios da expressão regular
                return regex.IsMatch(senha);
            }

            return false;
        }

        [GeneratedRegex(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")]
        private static partial Regex MyRegexSenhaValida();
    }
}
