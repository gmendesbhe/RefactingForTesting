using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting
{
    public class Bonus5anos : IBonus
    {
        public int TempoCasa
        {
            get
            {
                return 5;
            }
        }

        public decimal CalcularBonus(decimal aSalario)
        {
            return Math.Round(aSalario * 0.03M, 2);
        }
    }
}
