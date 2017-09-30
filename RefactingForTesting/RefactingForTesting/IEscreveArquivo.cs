using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting
{
    public interface IEscreveArquivo: IDisposable
    {
        void WriteLine(string aLine);
    }
}
