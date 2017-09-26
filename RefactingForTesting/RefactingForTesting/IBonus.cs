using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting
{
    public interface IBonus
    {
        int TempoCasa { get;}
        decimal CalcularBonus(decimal aSalario);
    }
}
