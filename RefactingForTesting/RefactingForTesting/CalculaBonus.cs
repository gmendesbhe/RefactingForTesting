using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting
{
    public class CalculaBonus:ICalculaBonus
    {
        IEnumerable<IBonus> listaBonus;
        public CalculaBonus(IEnumerable<IBonus> aListaBonus)
        {
            listaBonus = aListaBonus.OrderBy(b => b.TempoCasa);
        }

        public decimal CalcularBonus(int aTempoCasa, decimal aValor)
        {
            return listaBonus.FirstOrDefault(b => aTempoCasa < b.TempoCasa).CalcularBonus(aValor);
        }

        public Dictionary<BancoEnum, decimal> CalculaBonusPorBanco(IEnumerable<IGrouping<BancoEnum, Funcionario>> aLista)
        {
            var retorno = new Dictionary<BancoEnum, decimal>();
            foreach (var banco in aLista)
            {
                var valor = 0M;
                foreach (var func in banco)
                {
                    var tempoDeCasa = DateTime.Now.Year - func.Admissao.Year;
                    valor += this.CalcularBonus(tempoDeCasa, func.Salario);
                }
                retorno[banco.Key] = valor;
            }
            return retorno;
        }
    }
}
