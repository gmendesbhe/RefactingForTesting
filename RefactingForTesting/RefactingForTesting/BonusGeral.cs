using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting
{
    public class BonusGeral : IBonus
    {
        public int TempoCasa
        {
            get
            {
                return int.MaxValue;
            }
        }

        public decimal CalcularBonus(decimal aSalario)
        {
            return Math.Round(aSalario * 0.1M, 2);
        }
    }
}
