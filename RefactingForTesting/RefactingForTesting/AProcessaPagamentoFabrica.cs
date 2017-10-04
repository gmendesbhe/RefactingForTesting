using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting
{
public abstract    class AProcessaPagamentoFabrica
    {
        public abstract IProcessaPagamento processaPagamento { get; }
        private static AProcessaPagamentoFabrica _Instance;
        public static AProcessaPagamentoFabrica Instance
        {
            get
            {
                if (_Instance==null)
                {
                    _Instance = new ProcessaPagamentoFabrica();
                }
                return _Instance;
            }
        }
    }
}
