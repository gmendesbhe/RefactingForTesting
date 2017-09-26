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
            proc.GerarArquivoConsolidadoPagamento(new FuncionarioDados(), DateTime.Now, new StreamReader("c:\\temp\\depositos.csv"), new StreamWriter("c:\\temp\\depositos.csv"));
            //proc.GerarArquivoConsolidadoPagamento("c:\\temp\\depositos.csv");


        }
    }
}
