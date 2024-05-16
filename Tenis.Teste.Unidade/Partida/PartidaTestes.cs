using FluentAssertions;
using Tenis.Entidade;
using Tenis.Enum;
using Xunit;

namespace Tenis.Teste.Unidade.Entidade
{
    public class PartidaTestes
    {
        [Fact]
        public void DeveInicializarPartidaCorretamente()
        {
            // Arrange
            var jogador1 = new Jogador("Jogador 1");
            var jogador2 = new Jogador("Jogador 2");

            // Act
            var partida = new Partida(jogador1, jogador2);

            // Assert
            partida.PrimeiroJogador.Should().Be(jogador1);
            partida.SegundoJogador.Should().Be(jogador2);
            partida.Modo.Should().Be(Modo.Normal);
            partida.ProximoSaque.Should().Be(jogador1);
        }

        [Fact]
        public void DeveAtualizarPontuacaoJogadorCorretamente()
        {
            // Arrange
            var jogador1 = new Jogador("Jogador 1");
            var jogador2 = new Jogador("Jogador 2");
            var partida = new Partida(jogador1, jogador2);

            // Act
            partida.Pontuar(jogador1);

            // Assert
            jogador1.Pontuacao.Pontos.Should().Be(1);
        }

        [Fact]
        public void DevePontuarGameCorretamente()
        {
            // Arrange
            var primeiroJogador = new Jogador("Jogador 1")
            {
                Set = new Set(0),
                Game = new Game(0),
                Pontuacao = new Pontuacao(3)
            };

            var segundoJogador = new Jogador("Jogador 2")
            {
                Set = new Set(0),
                Game = new Game(0),
                Pontuacao = new Pontuacao(0)
            };

            // Act

            var partida = new Partida(primeiroJogador, segundoJogador);
            partida.Pontuar(primeiroJogador);
            

            // Assert
            primeiroJogador.Game.Games.Should().Be(1);
            segundoJogador.Pontuacao.Pontos.Should().Be(0);
        }

        [Fact]
        public void DevePontuarSetCorretamente()
        {
            // Arrange
            var primeiroJogador = new Jogador("Jogador 1")
            {
                Set = new Set(0),
                Game = new Game(5),
                Pontuacao = new Pontuacao(3)
            };

            var segundoJogador = new Jogador("Jogador 2")
            {
                Set = new Set(0),
                Game = new Game(0),
                Pontuacao = new Pontuacao(0)
            };
            var partida = new Partida(primeiroJogador, segundoJogador);

            // Act
           
            partida.Pontuar(primeiroJogador);

            // Assert
            primeiroJogador.Set.Sets.Should().Be(1);
            primeiroJogador.Game.Games.Should().Be(0);
        }

        [Fact]
        public void DeveAlternarSaqueCorretamente()
        {
            // Arrange
            var primeiroJogador = new Jogador("Jogador 1")
            {
                Set = new Set(1),
                Game = new Game(5),
                Pontuacao = new Pontuacao(2)
            };

            var segundoJogador = new Jogador("Jogador 2")
            {
                Set = new Set(1),
                Game = new Game(2),
                Pontuacao = new Pontuacao(3)
            };

            var partida = new Partida(primeiroJogador, segundoJogador);
            partida.Pontuar(segundoJogador);
            
            partida.ProximoSaque.Should().Be(segundoJogador);
        }

        [Fact]
        public void DeveAtivarModoDeuceCorretamente()
        {
            // Arrange
            var primeiroJogador = new Jogador("Jogador 1")
            {
                Set = new Set(1),
                Game = new Game(5),
                Pontuacao = new Pontuacao(3)
            };

            var segundoJogador = new Jogador("Jogador 2")
            {
                Set = new Set(1),
                Game = new Game(2),
                Pontuacao = new Pontuacao(2)
            };
            var partida = new Partida(primeiroJogador, segundoJogador);

            // Act
            partida.Pontuar(segundoJogador);
            
            // Assert
            partida.Modo.Should().Be(Modo.Deuce);
        }

        [Fact]
        public void DeveAtivarModoTieBreakCorretamente()
        {
            // Arrange
            var primeiroJogador = new Jogador("Jogador 1")
            {
                Set = new Set(1),
                Game = new Game(5),
                Pontuacao = new Pontuacao(3)
            };

            var segundoJogador = new Jogador("Jogador 2")
            {
                Set = new Set(1),
                Game = new Game(6),
                Pontuacao = new Pontuacao(2)
            };

            var partida = new Partida(primeiroJogador, segundoJogador);

            // Act
            partida.Pontuar(primeiroJogador); 

            // Assert
            partida.Modo.Should().Be(Modo.TieBreak);
        }
    }
}
