using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting
{
    public abstract class AFabricaWriter
    {
        public abstract IEscreveArquivo Writer { get; }
        private static AFabricaWriter _Instance;
        public static AFabricaWriter Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FabricaWriter();
                }
                return _Instance;
            }
        }
    }
}
