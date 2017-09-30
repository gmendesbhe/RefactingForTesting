using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting
{

    public enum BancoEnum { Itau, Bradesco, Caixa }
    public class Funcionario
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public DateTime Admissao { get; set; }
        public bool Demitido { get; set; }
        public BancoEnum Banco { get; set; }
        public override bool Equals(object obj)
        {
            var item = obj as Funcionario;
            if (item == null)
            {
                return false;
            }
            return this.Admissao == item.Admissao
                && this.Banco == item.Banco
                && this.Codigo==item.Codigo
                && this.Demitido==item.Demitido
                &&this.Nome==item.Nome
                && this.Salario==item.Salario;
        }
        public override int GetHashCode()
        {
            return (int)(Codigo*Salario);
        }
    }
    public interface IFuncionarioDados : IDisposable
    {
        List<Funcionario> BuscarFuncionarios();
        IEnumerable<Funcionario> FuncionariosAtivos(IEnumerable<Funcionario> listaFuncionarios);
        IEnumerable<IGrouping<BancoEnum, Funcionario>> FuncionariosAgrupBanco(IEnumerable<Funcionario> listaFuncionarios);
    }

    public class FuncionarioDados : IFuncionarioDados
    {
        private ILerArquivo _BaseFuncionarios;
        public FuncionarioDados(ILerArquivo aBaseFuncionarios)
        {
            this._BaseFuncionarios = aBaseFuncionarios;
        }
        public List<Funcionario> BuscarFuncionarios()
        {
            List<Funcionario> result = new List<Funcionario>();
            //Primeira linha é cabeçalho
            this._BaseFuncionarios.ReadLine();
            var linha = this._BaseFuncionarios.ReadLine();
            while (linha != null)
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

                linha = this._BaseFuncionarios.ReadLine();
            }

            return result;
        }

        public IEnumerable<Funcionario> FuncionariosAtivos(IEnumerable<Funcionario> listaFuncionarios)
        {
            return listaFuncionarios.Where(f => !f.Demitido);
        }

        public IEnumerable<IGrouping<BancoEnum, Funcionario>> FuncionariosAgrupBanco(IEnumerable<Funcionario> listaFuncionarios)
        {
            return listaFuncionarios.GroupBy(f => f.Banco);
        }

        #region IDisposable Support
        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this._BaseFuncionarios.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
