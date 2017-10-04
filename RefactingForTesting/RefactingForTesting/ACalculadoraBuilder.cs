using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting
{
    public abstract class ACalculadoraBuilder
    {
        protected List<IBonus> lista;
        protected bool VerificaLista<T>()where T:class
        {
            return lista.Count(b => b.GetType() == typeof(T)) > 0;
        }
        public abstract void Bonus10();
        public abstract void Bonus5();
        public abstract void Bonus3();
        public abstract void BonusGeral();
        private static ACalculadoraBuilder _Instance;
        public static ACalculadoraBuilder Instance
        {
            get
            {
                if (_Instance==null)
                {
                    _Instance = new CalculadoraBuilder();
                }
                return _Instance;
            }
        }

        public ICalculaBonus Build()
        {
            return new CalculaBonus(this.lista);
        }
    }
}
