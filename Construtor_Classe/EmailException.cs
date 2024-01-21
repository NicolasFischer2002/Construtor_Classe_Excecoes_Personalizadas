using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construtor_Classe
{
    public class EmailException(string? message) : Exception(message)
    {
    }

    public class EmailInvalidoException(string message) : EmailException(message)
    {
    }

    public class EmailRecuperacaoInvalidoException(string message) : EmailException(message)
    {
    }
}
