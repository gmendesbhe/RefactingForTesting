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
            var proc = AProcessaPagamentoFabrica.Instance.processaPagamento;
            var dados = AFabricaDados.Instance.Dados;
            var arquivo = AFabricaWriter.Instance.Writer;
            //var calculadora = AFabricaCalculadora.Instance.Calculadora;
            var calcBuilder = ACalculadoraBuilder.Instance;
            calcBuilder.Bonus10();
            calcBuilder.Bonus3();
            calcBuilder.Bonus5();
            calcBuilder.BonusGeral();
            var calculadora = calcBuilder.Build();
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
