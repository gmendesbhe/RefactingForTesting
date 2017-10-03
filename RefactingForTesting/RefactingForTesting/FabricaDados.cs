using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting
{
    public class FabricaDados:AFabricaDados
    {
        public override IFuncionarioDados Dados
        {
            get
            {
                var leitor = new LerArquivo(new StreamReader(@"..\..\..\..\func.csv"));
                return new FuncionarioDados(leitor);
            }
        }
    }
}
