using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting
{
    public class CalculadoraBuilder : ACalculadoraBuilder
    {
        public CalculadoraBuilder()
        {
            this.lista = new List<IBonus>();
        }
        public override void Bonus10()
        {
            if (VerificaLista<Bonus10anos>())
            {
                return;
            }
            this.lista.Add(new Bonus10anos());
        }

        public override void Bonus3()
        {
            if (VerificaLista<Bonus3anos>())
            {
                return;
            }
            this.lista.Add(new Bonus3anos());
        }

        public override void Bonus5()
        {
            if (VerificaLista<Bonus5anos>())
            {
                return;
            }
            this.lista.Add(new Bonus5anos());
        }

        public override void BonusGeral()
        {
            if (VerificaLista<BonusGeral>())
            {
                return;
            }
            this.lista.Add(new BonusGeral());
        }
    }
}
