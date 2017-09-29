using System.IO;

namespace RefactingForTesting
{
    public class FabricaWriter
    {
        public IEscreveArquivo Writer { get
            {
                return new EscreverArquivo(new StreamWriter(@"c:\temp\depositos.csv"));
            }
        }
    }
}