using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Domain.BlockChain.ValueObject
{
    public class Password
    {

        public Password()
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        {

        }

        public Password(string valor)
        {
            this.Valor = valor ?? throw new ArgumentNullException(nameof(Password));
        }

        public string Valor { get; set; }
    }
}
