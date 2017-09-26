using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting
{
    public interface ICalculaBonus
    {
        decimal CalcularBonus(int aTempoCasa, decimal aValor);
        Dictionary<BancoEnum, decimal> CalculaBonusPorBanco(IEnumerable<IGrouping<BancoEnum, Funcionario>> aLista, DateTime hoje);
    }
}
