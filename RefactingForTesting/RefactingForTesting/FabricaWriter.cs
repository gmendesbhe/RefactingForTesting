using System.IO;

namespace RefactingForTesting
{
    public class FabricaWriter:AFabricaWriter
    {
        public override IEscreveArquivo Writer
        {
            get
            {
                return new EscreverArquivo(new StreamWriter(@"c:\temp\depositos.csv"));
            }
        }
    }
}