using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting
{

    public enum BancoEnum { Itau, Bradesco, Caixa}
    public class Funcionario
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public DateTime Admissao { get; set; }
        public bool Demitido { get; set; }
        public BancoEnum Banco { get; set; }
    }

    public class FuncionarioDados
    {
        public List<Funcionario> BuscarFuncionarios()
        {
            List<Funcionario> result = new List<Funcionario>();
            using(var f = File.OpenText("func.csv"))
            {
                //Primeira linha é cabeçalho
                f.ReadLine();
                var linha = f.ReadLine();
                while(linha != null)
                {
                    var colunas = linha.Split(';');
                    var codigo = int.Parse(colunas[0].Trim());
                    var nome = colunas[1].Trim();
                    var salario = decimal.Parse(colunas[2].Trim(), System.Globalization.CultureInfo.GetCultureInfo("pt-br"));
                    var admissao = DateTime.Parse(colunas[3].Trim(), System.Globalization.CultureInfo.GetCultureInfo("pt-br"));
                    var demitido = colunas[4].Trim() == "S";
                    var banco = (BancoEnum)Enum.Parse(typeof(BancoEnum), colunas[5].Trim());

                    var funcionario = new Funcionario()
                    {
                        Codigo = codigo,
                        Nome = nome,
                        Salario = salario,
                        Admissao = admissao,
                        Demitido = demitido,
                        Banco = banco
                    };

                    result.Add(funcionario);

                    linha = f.ReadLine();
                }
            }

            return result;
        }
    }
}
