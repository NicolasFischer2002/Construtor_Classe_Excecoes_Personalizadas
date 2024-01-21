using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construtor_Classe
{
    public class SenhaInvalidaException(string message) : Exception(message)
    {
    }
}
