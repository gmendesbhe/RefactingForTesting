using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting
{
    public abstract class AFabricaDados
    {
        public abstract IFuncionarioDados Dados { get; }
        private static AFabricaDados _Instance;
        public static AFabricaDados Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FabricaDados();
                }
                return _Instance;
            }
        }
    }
}
