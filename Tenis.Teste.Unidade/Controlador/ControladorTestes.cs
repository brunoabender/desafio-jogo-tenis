using FluentAssertions;
using Tenis.Controlador;
using Tenis.Entidade;
using Tenis.Enum;
using Xunit;

namespace Tenis.Teste.Unidade.Controlador
{
    public class ControladorTestes
    {
        [Theory]
        [InlineData(Acao.PontuarPrimeiroJogador, 1, 0)]
        [InlineData(Acao.PontuarSegundoJogador, 0, 1)]
        [InlineData(Acao.NovoJogo, 0, 0)]
        public void DeveExecutarAcoesCorretamente(Acao acao, int pontuacaoEsperadaPrimeiroJogador, int pontuacaoEsperadaSegundoJogador)
        {
            // Arrange
            var jogador1 = new Jogador("Jogador 1");
            var jogador2 = new Jogador("Jogador 2");
            var partida = new Partida(jogador1, jogador2);
            var controlador = new ControladorPartida(partida);

            // Act
            controlador.Executar(acao);

            // Assert
            jogador1.Pontuacao.Pontos.Should().Be(pontuacaoEsperadaPrimeiroJogador);
            jogador2.Pontuacao.Pontos.Should().Be(pontuacaoEsperadaSegundoJogador);
        }
    }
}
