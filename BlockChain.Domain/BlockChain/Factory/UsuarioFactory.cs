using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Domain.BlockChain.Factory
{
    public static class UsuarioFactory
    {
        public static Usuario Create(Carteira carteira)
        {
            if (carteira == null)
                throw new ArgumentNullException("Para criar um usuario, o usuario deve ter no minimo uma carteira");

            return new Usuario()
            {
                Carteiras = new List<Carteira>() { carteira }
            };
        }

    }
}
