using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Construtor_Classe
{
    public class Criptografia
    {
        public static string CalcularHashMD5(string input)
        {
            // Converte a string para bytes
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Calcula o hash MD5
            byte[] hashBytes = MD5.HashData(inputBytes);

            // Converte os bytes do hash para uma representação hexadecimal
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
                sb.Append(hashBytes[i].ToString("x2")); // "x2" formata para dois dígitos hexadecimais

            return sb.ToString();
        }
    }
}
