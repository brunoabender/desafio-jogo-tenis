﻿using FluentAssertions;
using Tenis.Entidade;
using Tenis.Placar;
using Xunit;

namespace Tenis.Teste.Unidade.Placar
{
    [Collection("RecursoCompartilhado")]
    public class PlacarTieBreakTestes
    {
        [Fact]
        public void DeveImprimirPlacarTieBreakCorretamente()
        {
            var primeiroJogador = new Jogador("Jogador 1")
            {
                Set = new Set(0),
                Game = new Game(6),
                Pontuacao = new Pontuacao(0)
            };

            var segundoJogador = new Jogador("Jogador 2")
            {
                Set = new Set(0),
                Game = new Game(6),
                Pontuacao = new Pontuacao(0)
            };


            // Arrange
            var partida = new Partida(primeiroJogador, segundoJogador);
            var placarDeuce = new PlacarTieBreak();

            using var stringWritter = new StringWriter();
            Console.SetOut(stringWritter);

            // Act
            placarDeuce.Obter(partida);

            // Assert
            var resultado = stringWritter.ToString().Trim();
            resultado.Should().Contain("Placar de Tênis:");
            resultado.Should().Contain("Jogador 1: 0 sets, 6 games, 0 pontos no game atual");
            resultado.Should().Contain("Jogador 2: 0 sets, 6 games, 0 pontos no game atual");
            resultado.Should().Contain("Próximo saque: Jogador 1");
            resultado.Should().Contain("Modo: TieBreak");
        }
    }
}
