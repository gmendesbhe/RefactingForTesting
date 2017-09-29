using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactingForTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting.Tests
{
    [TestClass()]
    public class CalculaBonusTests
    {
        private CalculaBonus calculadora;
        private IEnumerable<IGrouping<BancoEnum, Funcionario>> listaAgrupada;

        [TestInitialize]
        public void Initialize()
        {
            var listaBonus = new List<IBonus>
            {
                new Bonus3anos(),
                new BonusGeral(),
                new Bonus10anos(),
                new Bonus5anos()
            };
            this.calculadora = new CalculaBonus(listaBonus);
            var lista = new List<Funcionario>()
            {
                new Funcionario()
                {
                    Admissao= new DateTime(2017,05,11),
                    Banco=BancoEnum.Caixa,
                    Codigo=1,
                    Demitido=false,
                    Nome="joao",
                    Salario=3500M
                },
                new Funcionario()
                {
                    Admissao= new DateTime(2017,05,11),
                    Banco=BancoEnum.Caixa,
                    Codigo=1,
                    Demitido=false,
                    Nome="juca",
                    Salario=3500M
                },
                new Funcionario()
                {
                    Admissao = new DateTime(2017,01,11),
                    Banco = BancoEnum.Bradesco,
                    Codigo=2,
                    Demitido=false,
                    Nome="pedro",
                    Salario=2000M
                },
                new Funcionario()
                {
                    Admissao= new DateTime(2018,06,11),
                    Banco=BancoEnum.Itau,
                    Codigo=1,
                    Demitido=false,
                    Nome="maria",
                    Salario=4500M
                }
            };
            this.listaAgrupada = lista.GroupBy(f => f.Banco);
        }
        [TestMethod()]
        public void CalculaBonusPorBancoAte3anos()
        {

            var data = new DateTime(2018, 07, 22);
            var esperado = new Dictionary<BancoEnum, decimal>
            {
                {BancoEnum.Caixa,0M },
                { BancoEnum.Bradesco,0M },
                {BancoEnum.Itau,0M }
            };
            //act
            var dic = this.calculadora.CalculaBonusPorBanco(listaAgrupada, data);
            bool iguais = true;
            foreach (var item in dic)
            {
                if (item.Value != esperado[item.Key])
                {
                    iguais = false;
                    break;
                }
            }
            //assert
            Assert.IsTrue(iguais);
        }
        [TestMethod()]
        public void CalculaBonusPorBancoEntre3e5anos()
        {
            var data = new DateTime(2020, 05, 20);
            var esperado = new Dictionary<BancoEnum, decimal>
            {
                {BancoEnum.Caixa,210M },
                { BancoEnum.Bradesco,60M },
                {BancoEnum.Itau,0M }
            };
            //act
            var dic = this.calculadora.CalculaBonusPorBanco(listaAgrupada, data);
            bool iguais = true;
            foreach (var item in dic)
            {
                if (item.Value != esperado[item.Key])
                {
                    iguais = false;
                    break;
                }
            }
            //assert
            Assert.IsTrue(iguais);
        }
        [TestMethod()]
        public void CalculaBonusPorBancoEntre5e10anos()
        {

            var data = new DateTime(2022, 05, 20);
            var esperado = new Dictionary<BancoEnum, decimal>
            {
                {BancoEnum.Caixa,350M },
                { BancoEnum.Bradesco,100M },
                {BancoEnum.Itau,135M }
            };
            //act
            var dic = this.calculadora.CalculaBonusPorBanco(listaAgrupada, data);
            bool iguais = true;
            foreach (var item in dic)
            {
                if (item.Value != esperado[item.Key])
                {
                    iguais = false;
                    break;
                }
            }
            //assert
            Assert.IsTrue(iguais);
        }
        [TestMethod()]
        public void CalculaBonusPorBancoMaior10anos()
        {

            var data = new DateTime(2027, 05, 20);
            var esperado = new Dictionary<BancoEnum, decimal>
            {
                {BancoEnum.Caixa,700M },
                { BancoEnum.Bradesco,200M },
                {BancoEnum.Itau,225M }
            };
            //act
            var dic = this.calculadora.CalculaBonusPorBanco(listaAgrupada, data);
            bool iguais = true;
            foreach (var item in dic)
            {
                if (item.Value != esperado[item.Key])
                {
                    iguais = false;
                    break;
                }
            }
            //assert
            Assert.IsTrue(iguais);
        }
    }
}