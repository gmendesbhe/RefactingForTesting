using System;

namespace RefactingForTesting
{
    public interface IProcessaPagamento
    {
        void GerarArquivoConsolidadoPagamento(IFuncionarioDados dados, DateTime DataHj, ICalculaBonus aCalculaBonus, IEscreveArquivo gravarArquivo);
    }
}