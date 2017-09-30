using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RefactingForTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting.Tests
{
    [TestClass()]
    public class FuncionarioDadosTests
    {
        [TestMethod()]
        public void BuscarFuncionariosTestArquivoCorreto()
        {
            var lerArquivoMock = new Mock<ILerArquivo>();
            lerArquivoMock
                .SetupSequence(l => l.ReadLine())
                .Returns("Cabeçalho")
                .Returns("1;Aarão Piteira; 9.442,41 ;04/05/2007;N;Itau")
                .Returns("2;Abílio Homem; 3.230,84 ;03/02/1994;N;Bradesco")
                .Returns("3;Acacio Paz; 9.659,03 ;14/11/1995;S;Bradesco")
                .Returns(null);
            var esperado = new List<Funcionario>
            {
                new Funcionario
                {
                    Codigo = 1,
                    Nome = "Aarão Piteira",
                    Salario=9442.41M,
                    Admissao = new DateTime(2007,05,04),
                    Demitido=false,
                    Banco=BancoEnum.Itau
                },
                 new Funcionario
                {
                    Codigo = 2,
                    Nome = "Abílio Homem",
                    Salario=3230.84M,
                    Admissao = new DateTime(1994,02,03),
                    Demitido=false,
                    Banco=BancoEnum.Bradesco
                },
                  new Funcionario
                {
                    Codigo = 3,
                    Nome = "Acacio Paz",
                    Salario=9659.03M,
                    Admissao = new DateTime(1995,11,14),
                    Demitido=true,
                    Banco=BancoEnum.Bradesco
                }
            };
            var funcDados = new FuncionarioDados(lerArquivoMock.Object);
            var iguais = true;

            var result = funcDados.BuscarFuncionarios();
            for (int i = 0; i < result.Count(); i++)
            {
                if (!result[i].Equals(esperado[i]))
                {
                    iguais = false;
                    break;
                }
            }

            lerArquivoMock.Verify(l => l.ReadLine(), Times.Exactly(5));
            Assert.AreEqual(3, result.Count);
            Assert.IsTrue(iguais);
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void BuscarFuncionariosTestCodigoComErro()
        {
            var lerArquivoMock = new Mock<ILerArquivo>();
            lerArquivoMock
                .SetupSequence(l => l.ReadLine())
                .Returns("Cabeçalho")
                .Returns("1;Aarão Piteira; 9.442,41 ;04/05/2007;N;Itau")
                .Returns("a;Abílio Homem; 3.230,84 ;03/02/1994;N;Bradesco")
                .Returns("3;Acacio Paz; 9.659,03 ;14/11/1995;S;Bradesco")
                .Returns(null);

            var funcDados = new FuncionarioDados(lerArquivoMock.Object);
            funcDados.BuscarFuncionarios();

        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void BuscarFuncionariosTestBancoComErro()
        {
            var lerArquivoMock = new Mock<ILerArquivo>();
            lerArquivoMock
                .SetupSequence(l => l.ReadLine())
                .Returns("Cabeçalho")
                .Returns("1;Aarão Piteira; 9.442,41 ;04/05/2007;N;Itau")
                .Returns("2;Abílio Homem; 3.230,84 ;03/02/1994;N;Bradesco")
                .Returns("3;Acacio Paz; 9.659,03 ;14/11/1995;S;Bradescoz")
                .Returns(null);

            var funcDados = new FuncionarioDados(lerArquivoMock.Object);
            funcDados.BuscarFuncionarios();

        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void BuscarFuncionariosTestSalarioVirgulaSeparadorMilhar()
        {
            var lerArquivoMock = new Mock<ILerArquivo>();
            lerArquivoMock
                .SetupSequence(l => l.ReadLine())
                .Returns("Cabeçalho")
                .Returns("1;Aarão Piteira; 9,442,41 ;04/05/2007;N;Itau")
                .Returns(null);

            var funcDados = new FuncionarioDados(lerArquivoMock.Object);
            funcDados.BuscarFuncionarios();

        }
        [TestMethod()]
        public void BuscarFuncionariosTestSalarioPontoSeparadorDecimal()
        {
            var lerArquivoMock = new Mock<ILerArquivo>();
            lerArquivoMock
                .SetupSequence(l => l.ReadLine())
                .Returns("Cabeçalho")
                .Returns("1;Aarão Piteira; 9.442.41 ;04/05/2007;N;Itau")
                .Returns(null);

            var funcDados = new FuncionarioDados(lerArquivoMock.Object);
            var result = funcDados.BuscarFuncionarios();

            Assert.AreEqual(944241, result.Single(f => f.Codigo == 1).Salario);

        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void BuscarFuncionariosTestDataComErro()
        {
            var lerArquivoMock = new Mock<ILerArquivo>();
            lerArquivoMock
                .SetupSequence(l => l.ReadLine())
                .Returns("Cabeçalho")
                .Returns("1;Aarão Piteira; 9,442,41 ;04/22/2007;N;Itau")
                .Returns(null);

            var funcDados = new FuncionarioDados(lerArquivoMock.Object);
            funcDados.BuscarFuncionarios();

        }
    }
}