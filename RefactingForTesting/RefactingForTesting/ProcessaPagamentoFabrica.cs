using System;

namespace RefactingForTesting
{
    public class ProcessaPagamentoFabrica : AProcessaPagamentoFabrica
    {
        public override IProcessaPagamento processaPagamento
        {
            get
            {
                return new ProcessaPagamento();
            }
        }
    }
}