using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting
{
    public class ProcessaPagamento
    {

        public void GerarArquivoConsolidadoPagamento(string nomeArquivo)
        {
            FuncionarioDados dados = new FuncionarioDados();
            var lista = dados.BuscarFuncionarios();

            var listaFiltrada = lista.Where(f => !f.Demitido);

            //Processa pagamentos por banco
            var listaAgrupada = listaFiltrada.GroupBy(f => f.Banco);
            
            using (var f = File.CreateText(nomeArquivo))
            {
                foreach(var banco in listaAgrupada)
                {
                    var valor = 0M;
                    foreach(var func in banco)
                    {
                        var bonus = 0.0M;
                        var tempoDeCasa = DateTime.Today.Year - func.Admissao.Year;
                        if (tempoDeCasa < 3)
                            bonus = 0;
                        else
                            if(tempoDeCasa < 5)
                                bonus = 0.03M;
                            else
                                if (tempoDeCasa < 10)
                                    bonus = 0.05M;
                                else
                                    bonus = 0.1M;

                        valor += Math.Round(func.Salario * bonus, 2);
                    }

                    f.WriteLine($"{banco.Key};{valor}");
                }
            }


        }

    }
}
