using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting
{
    public class LerArquivo : ILerArquivo
    {
        private StreamReader _Reader;
        

        public LerArquivo(StreamReader aReader)
        {
            this._Reader = aReader;
        }
        public string ReadLine()
        {
            return this._Reader.ReadLine();
        }

        #region IDisposable Support
        private bool disposed = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    this._Reader.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
