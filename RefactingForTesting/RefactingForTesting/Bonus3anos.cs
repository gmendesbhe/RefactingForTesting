using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting
{
    public class Bonus3anos : IBonus
    {
        public int TempoCasa
        {
            get
            {
                return 3;
            }
        }

        public decimal CalcularBonus(decimal aSalario)
        {
            return 0;
        }
    }
}
