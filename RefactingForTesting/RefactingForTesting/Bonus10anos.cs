using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting
{
    public class Bonus10anos : IBonus
    {
        public int TempoCasa
        {
            get
            {
                return 10;
            }
        }

        public decimal CalcularBonus(decimal aSalario)
        {
            return Math.Round(aSalario * 0.05M, 2);
        }
    }
}
