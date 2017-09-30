using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RefactingForTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting.Tests
{
    [TestClass()]
    public class ProcessaPagamentoTests
    {
        Mock<IFuncionarioDados> dadosMock;
        ProcessaPagamento proc;
        DateTime data;
        Mock<IEscreveArquivo> arquivoMock;
        Mock<ICalculaBonus> calculadoraMock;

        [TestInitialize]
        public void Initialize()
        {
            this.proc = new ProcessaPagamento();
            this.data = new DateTime(2017, 09, 29);
            this.dadosMock = new Mock<IFuncionarioDados>();
            this.arquivoMock = new Mock<IEscreveArquivo>();
            this.calculadoraMock = new Mock<ICalculaBonus>();
        }
        [TestMethod()]
        public void GerarArquivoConsolidadoPagamento1Linha()
        {
            //arrange
            var lista = new List<Funcionario>()
            {
                new Funcionario()
                {
                    Admissao= new DateTime(2017,05,11),
                    Banco=BancoEnum.Itau,
                    Codigo=1,
                    Demitido=false,
                    Nome="joao",
                    Salario=3500M
                },
                new Funcionario()
                {
                    Admissao= new DateTime(2017,01,11),
                    Banco=BancoEnum.Itau,
                    Codigo=2,
                    Demitido=false,
                    Nome="pedro",
                    Salario=2000M
                },
                new Funcionario()
                {
                    Admissao= new DateTime(2017,06,11),
                    Banco=BancoEnum.Itau,
                    Codigo=1,
                    Demitido=false,
                    Nome="maria",
                    Salario=4500M
                }
            };
            var listaAgrupada = lista.GroupBy(f => f.Banco);
            var dic = new Dictionary<BancoEnum, decimal>()
            {
                {BancoEnum.Itau,  0M}
            };

            dadosMock
                .Setup(d => d.BuscarFuncionarios());
            dadosMock
                .Setup(d => d.FuncionariosAtivos(It.IsAny<IEnumerable<Funcionario>>()));
            dadosMock
                .Setup(d => d.FuncionariosAgrupBanco(It.IsAny<IEnumerable<Funcionario>>()))
                .Returns(listaAgrupada);

            calculadoraMock.Setup(c => c.CalculaBonusPorBanco(listaAgrupada, data))
                .Returns(dic);

            //act
            proc.GerarArquivoConsolidadoPagamento(dadosMock.Object, data, calculadoraMock.Object, arquivoMock.Object);

            //assert
            arquivoMock.Verify(a=>a.WriteLine("Itau:0"),Times.Once);
        }
        [TestMethod()]
        public void GerarArquivoConsolidadoPagamento2Linhas()
        {
            //arrange
            var lista = new List<Funcionario>()
            {
                new Funcionario()
                {
                    Admissao= new DateTime(2017,05,11),
                    Banco=BancoEnum.Itau,
                    Codigo=1,
                    Demitido=false,
                    Nome="joao",
                    Salario=3500M
                },
                new Funcionario()
                {
                    Admissao= new DateTime(2017,01,11),
                    Banco=BancoEnum.Itau,
                    Codigo=2,
                    Demitido=false,
                    Nome="pedro",
                    Salario=2000M
                },
                new Funcionario()
                {
                    Admissao= new DateTime(2017,06,11),
                    Banco=BancoEnum.Bradesco,
                    Codigo=1,
                    Demitido=false,
                    Nome="maria",
                    Salario=4500M
                }
            };
            var listaAgrupada = lista.GroupBy(f => f.Banco);
            var dic = new Dictionary<BancoEnum, decimal>()
            {
                {BancoEnum.Itau,  0M},
                {BancoEnum.Bradesco,  0M}
            };

            dadosMock
                .Setup(d => d.BuscarFuncionarios());
            dadosMock
                .Setup(d => d.FuncionariosAtivos(It.IsAny<IEnumerable<Funcionario>>()));
            dadosMock
                .Setup(d => d.FuncionariosAgrupBanco(It.IsAny<IEnumerable<Funcionario>>()))
                .Returns(listaAgrupada);

            calculadoraMock.Setup(c => c.CalculaBonusPorBanco(listaAgrupada, data))
                .Returns(dic);

            //act
            proc.GerarArquivoConsolidadoPagamento(dadosMock.Object, data, calculadoraMock.Object, arquivoMock.Object);

            //assert
            arquivoMock.Verify(a => a.WriteLine(It.IsAny<string>()), Times.Exactly(2));
            arquivoMock.Verify(a => a.WriteLine("Itau:0"), Times.Once);
            arquivoMock.Verify(a => a.WriteLine("Bradesco:0"), Times.Once);
        }
    }
}