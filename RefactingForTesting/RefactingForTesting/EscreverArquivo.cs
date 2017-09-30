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
        private bool disposed = false;
        private StreamWriter _Writer;
        public EscreverArquivo(StreamWriter aWriter)
        {
            this._Writer = aWriter;
        }

        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {

            if (!disposed)
            {
                if (disposing)
                {
                    this._Writer.Dispose();
                }

                disposed = true;
            }
        }

        public void WriteLine(string aLine)
        {
            this._Writer.WriteLine(aLine);
            this._Writer.Flush();
        }
    }
}
