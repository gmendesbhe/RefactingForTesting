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
            var dados = AFabricaDados.Instance.Dados;
            var arquivo = AFabricaWriter.Instance.Writer;
            var calculadora = AFabricaCalculadora.Instance.Calculadora;
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
