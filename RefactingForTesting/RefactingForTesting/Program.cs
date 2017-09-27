using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var proc = new ProcessaPagamento();
            var list = new List<IBonus>()
            {
                new Bonus10anos(),
                new Bonus3anos(),
                new Bonus5anos(),
                new BonusGeral()
            };

            proc.GerarArquivoConsolidadoPagamento(new FuncionarioDados(), DateTime.Now, new CalculaBonus(list), new StreamReader(@"..\func.csv"), new StreamWriter(@"c:\temp\depositos.csv"));

        }
    }
}
