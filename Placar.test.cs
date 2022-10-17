using NUnit.Framework;

namespace Boliche
{
    [TestFixture]
    public class PlacarTest
    {
        [Test]
        public void NenhumaPontuacao_DeveriaRetornarZero()
        {
            var quadros = new List<IList<string>>() {
                new List<string>() { "-", "-" },
                new List<string>() { "-", "-" },
                new List<string>() { "-", "-" },
                new List<string>() { "-", "-" },
                new List<string>() { "-", "-" },
                new List<string>() { "-", "-" },
                new List<string>() { "-", "-" },
                new List<string>() { "-", "-" },
                new List<string>() { "-", "-" },
                new List<string>() { "-", "-" },
            };
            Assert.AreEqual(0, Placar.Soma(quadros));
        }

        [Test]
        public void NenhumSpareOuStrike_DeveriaRetornarSomenteSomaDosValores()
        {
            var quadros = new List<IList<string>>() {
                new List<string>() { "-", "1" },
                new List<string>() { "1", "-" },
                new List<string>() { "9", "-" },
                new List<string>() { "-", "9" },
                new List<string>() { "1", "8" },
                new List<string>() { "8", "1" },
                new List<string>() { "4", "5" },
                new List<string>() { "5", "4" },
                new List<string>() { "3", "6" },
                new List<string>() { "6", "3" },
            };
            Assert.AreEqual(74, Placar.Soma(quadros));
        }

        [Test]
        public void ComUmSpare_DeveSomarPrimeiroValorDoProximoQuadro()
        {
            var quadros = new List<IList<string>>() {
                new List<string>() { "-", "1" },
                new List<string>() { "1", "-" },
                new List<string>() { "9", "-" },
                new List<string>() { "-", "9" },
                new List<string>() { "1", "8" },
                new List<string>() { "8", "/" },
                new List<string>() { "4", "5" },
                new List<string>() { "5", "4" },
                new List<string>() { "3", "6" },
                new List<string>() { "6", "3" },
            };
            Assert.AreEqual(79, Placar.Soma(quadros));
        }

        [Test]
        public void ComSpareEmTodosMenosNoUltimo_DeveSempreSomarPrimeiroValorDoProximoQuadro()
        {
            var quadros = new List<IList<string>>() {
                new List<string>() { "-", "/" },
                new List<string>() { "1", "/" },
                new List<string>() { "9", "/" },
                new List<string>() { "-", "/" },
                new List<string>() { "1", "/" },
                new List<string>() { "8", "/" },
                new List<string>() { "4", "/" },
                new List<string>() { "5", "/" },
                new List<string>() { "3", "/" },
                new List<string>() { "6", "1" },
            };
            Assert.AreEqual(134, Placar.Soma(quadros));
        }

        [Test]
        public void ComSpareNoUltimo_DeveSomarTerceiroValorDoQuadro()
        {
            var quadros = new List<IList<string>>() {
                new List<string>() { "-", "/" },
                new List<string>() { "1", "/" },
                new List<string>() { "9", "/" },
                new List<string>() { "-", "/" },
                new List<string>() { "1", "/" },
                new List<string>() { "8", "/" },
                new List<string>() { "4", "/" },
                new List<string>() { "5", "/" },
                new List<string>() { "3", "/" },
                new List<string>() { "6", "/", "1" },
            };
            Assert.AreEqual(138, Placar.Soma(quadros));
        }

        [Test]
        public void ComUmStrike_DeveSomarValorTotalDoProximoQuadro()
        {
            var quadros = new List<IList<string>>() {
                new List<string>() { "1", "4" },
                new List<string>() { "-", "-" },
                new List<string>() { "8", "1" },
                new List<string>() { "X" },
                new List<string>() { "3", "5" },
                new List<string>() { "3", "2" },
                new List<string>() { "2", "4" },
                new List<string>() { "5", "2" },
                new List<string>() { "1", "-" },
                new List<string>() { "8", "1" },
            };
            Assert.AreEqual(68, Placar.Soma(quadros));
        }

        [Test]
        public void ComStrikeMasSemStrikeSeguidos_DeveSempreSomarValoresDoProximoQuadro()
        {
            var quadros = new List<IList<string>>() {
                new List<string>() { "X" },
                new List<string>() { "-", "-" },
                new List<string>() { "8", "1" },
                new List<string>() { "X" },
                new List<string>() { "3", "5" },
                new List<string>() { "X" },
                new List<string>() { "2", "4" },
                new List<string>() { "5", "2" },
                new List<string>() { "1", "-" },
                new List<string>() { "8", "1" },
            };
            Assert.AreEqual(84, Placar.Soma(quadros));
        }

        [Test]
        public void ComStrikesSeguidos_DeveSempreSomarValoresDasProximasDuasJogadas()
        {
            var quadros = new List<IList<string>>() {
                new List<string>() { "X" },
                new List<string>() { "-", "-" },
                new List<string>() { "8", "1" },
                new List<string>() { "X" },
                new List<string>() { "X" },
                new List<string>() { "X" },
                new List<string>() { "2", "4" },
                new List<string>() { "5", "2" },
                new List<string>() { "1", "-" },
                new List<string>() { "8", "1" },
            };
            Assert.AreEqual(110, Placar.Soma(quadros));
        }

        [Test]
        public void ComStrikeNoPenultimoQuadro_DeveSempreSomarValoresSomenteDasProximasDuasJogadas()
        {
            var quadros = new List<IList<string>>() {
                new List<string>() { "-", "1" },
                new List<string>() { "1", "-" },
                new List<string>() { "9", "-" },
                new List<string>() { "-", "9" },
                new List<string>() { "1", "8" },
                new List<string>() { "8", "1" },
                new List<string>() { "4", "5" },
                new List<string>() { "5", "4" },
                new List<string>() { "X" },
                new List<string>() { "8", "/", "4" },
            };
            Assert.AreEqual(90, Placar.Soma(quadros));
        }

        [Test]
        public void ComStrikeEmTodosQuadros_DeveAtingirSomaMaxima()
        {
            var quadros = new List<IList<string>>() {
                new List<string>() { "X" },
                new List<string>() { "X" },
                new List<string>() { "X" },
                new List<string>() { "X" },
                new List<string>() { "X" },
                new List<string>() { "X" },
                new List<string>() { "X" },
                new List<string>() { "X" },
                new List<string>() { "X" },
                new List<string>() { "X", "X", "X" },
            };
            Assert.AreEqual(300, Placar.Soma(quadros));
        }

        [Test]
        public void ComUmStrikeNoUltimoQuadro_DeveSomarDoisUltimosValoresDoQuadro()
        {
            var quadros = new List<IList<string>>() {
                new List<string>() { "-", "1" },
                new List<string>() { "1", "-" },
                new List<string>() { "9", "-" },
                new List<string>() { "-", "9" },
                new List<string>() { "1", "8" },
                new List<string>() { "8", "1" },
                new List<string>() { "4", "5" },
                new List<string>() { "5", "4" },
                new List<string>() { "3", "6" },
                new List<string>() { "X", "8", "1" },
            };
            Assert.AreEqual(84, Placar.Soma(quadros));
        }

        [Test]
        public void ComStrikesESpares_DeveSomarOsValoresCorretamente()
        {
            var quadros = new List<IList<string>>() {
                new List<string>() { "8", "/" },
                new List<string>() { "9", "-" },
                new List<string>() { "4", "4" },
                new List<string>() { "7", "2" },
                new List<string>() { "9", "-" },
                new List<string>() { "X" },
                new List<string>() { "X" },
                new List<string>() { "8", "-" },
                new List<string>() { "3", "5" },
                new List<string>() { "9", "/", "X" },
            };
            Assert.AreEqual(136, Placar.Soma(quadros));
        }

        #region Testes de pré-condições

        [Test]
        public void DeveDispararExcecao_QuandoRecebeMenosde10Rodadas()
        {
            var quadros = new List<IList<string>>() {
                new List<string>() { "-", "-" },
            };

            Assert.Throws<ArgumentException>(() => Placar.Soma(quadros));
        }

        [Test]
        public void DeveDispararExcecao_QuandoRecebeMaisde10Rodadas()
        {
            var quadros = new List<IList<string>>() {
                new List<string>() { "-", "1" },
                new List<string>() { "1", "-" },
                new List<string>() { "9", "-" },
                new List<string>() { "-", "9" },
                new List<string>() { "1", "8" },
                new List<string>() { "8", "1" },
                new List<string>() { "4", "5" },
                new List<string>() { "5", "4" },
                new List<string>() { "3", "6" },
                new List<string>() { "-", "1" },
                new List<string>() { "1", "-" },
            };

            Assert.Throws<ArgumentException>(() => Placar.Soma(quadros));
        }

        #endregion
    }
}
