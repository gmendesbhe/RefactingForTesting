namespace RefactingForTesting
{
    public abstract class AFabricaCalculadora
    {
        public abstract ICalculaBonus Calculadora { get; }
        private static AFabricaCalculadora _Instance;
        public static AFabricaCalculadora Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FabricaCalculadora();
                }
                return Instance;
            }
        }
    }
}