﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting
{
    public class ProcessaPagamento:IProcessaPagamento
    {

        public void GerarArquivoConsolidadoPagamento(IFuncionarioDados dados, DateTime DataHj, ICalculaBonus aCalculaBonus, IEscreveArquivo gravarArquivo)
        {
            var lista = dados.BuscarFuncionarios();

            var listaFiltrada = dados.FuncionariosAtivos(lista);

            var listaAgrupada = dados.FuncionariosAgrupBanco(listaFiltrada);

            var dic = aCalculaBonus.CalculaBonusPorBanco(listaAgrupada, DataHj);
            foreach (var item in dic)
            {
                gravarArquivo.WriteLine($"{item.Key}:{item.Value}");
            }
        }

    }
}
