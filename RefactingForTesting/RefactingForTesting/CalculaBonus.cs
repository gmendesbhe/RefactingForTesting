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

        //public Dictionary<BancoEnum, decimal> CalculaBonus(IEnumerable<IGrouping<BancoEnum, Funcionario>> aLista)
        //{
        //    var retorno = new Dictionary<BancoEnum, decimal>();
        //    foreach (var banco in aLista)
        //    {
        //        var valor = 0M;
        //        foreach (var func in banco)
        //        {
        //            //var bonus = 0.0M;
        //            //var tempoDeCasa = hoje.Year - func.Admissao.Year;
        //            //if (tempoDeCasa < 3)
        //            //    bonus = 0;
        //            //else
        //            //    if (tempoDeCasa < 5)
        //            //    bonus = 0.03M;
        //            //else
        //            //        if (tempoDeCasa < 10)
        //            //    bonus = 0.05M;
        //            //else
        //            //    bonus = 0.1M;

        //            //valor += Math.Round(func.Salario * bonus, 2);
        //        }
        //        retorno[banco.Key] = valor;
        //    }
        //    return retorno;
        //}
    }
}
