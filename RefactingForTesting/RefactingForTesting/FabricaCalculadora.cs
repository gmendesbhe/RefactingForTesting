using System.Collections.Generic;

namespace RefactingForTesting
{
    public class FabricaCalculadora:AFabricaCalculadora
    {
        public override ICalculaBonus Calculadora
        {
            get
            {
                var list = new List<IBonus>()
                {
                    new Bonus10anos(),
                    new Bonus3anos(),
                    new Bonus5anos(),
                    new BonusGeral()
                };
                return new CalculaBonus(list);
            }
        }
    }
}