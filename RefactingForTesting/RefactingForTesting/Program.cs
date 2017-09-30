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
            var dados = new FabricaDados().Dados;
            var arquivo = new FabricaWriter().Writer;
            var calculadora = new FabricaCalculadora().Calculadora;
            using (dados)
            {
                using (arquivo)
                {
                    proc.GerarArquivoConsolidadoPagamento(dados, DateTime.Now, calculadora, arquivo);
                } 
            }

        }
    }
}
