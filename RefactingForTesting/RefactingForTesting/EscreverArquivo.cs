using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting
{
    public class EscreverArquivo : IEscreveArquivo
    {
        private StreamWriter _Writer;
        public EscreverArquivo(StreamWriter aWriter)
        {
            this._Writer = aWriter;
        }
        public void WriteLine(string aLine)
        {
            throw new NotImplementedException();
        }
    }
}
