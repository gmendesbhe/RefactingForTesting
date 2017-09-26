using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting
{
    class Bonus3anos : IBonus
    {
        public int TempoCasa
        {
            get
            {
                return 3;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public decimal CalcularBonus(decimal aSalario)
        {
            return 0;
        }
    }
}
