﻿using FluentAssertions;
using Tenis.Entidade;
using Tenis.Placar;
using Xunit;

namespace Tenis.Teste.Unidade.Placar
{
    [Collection("RecursoCompartilhado")]
    public class PlacarTieBreakTests
    {
        [Fact]
        public void DeveImprimirPlacarTieBreakCorretamente()
        {
            var primeiroJogador = new Jogador("Jogador 1")
            {
                Set = new Set(0),
                Game = new Game(5),
                Pontuacao = new Pontuacao(0)
            };

            var segundoJogador = new Jogador("Jogador 2")
            {
                Set = new Set(0),
                Game = new Game(5),
                Pontuacao = new Pontuacao(0)
            };


            // Arrange
            var partida = new Partida(primeiroJogador, segundoJogador);
            var placarDeuce = new PlacarDeuce();

            using var stringWritter = new StringWriter();
            Console.SetOut(stringWritter);

            // Act
            placarDeuce.Obter(partida);

            // Assert
            var resultado = stringWritter.ToString().Trim();
            resultado.Should().Contain("Placar de Tênis:");
            resultado.Should().Contain("Jogador 1: 1 sets, 1 games, Deuce");
            resultado.Should().Contain("Jogador 2: 1 sets, 2 games, Deuce");
            resultado.Should().Contain("Próximo saque: Jogador 1");
            resultado.Should().Contain("Modo: Deuce");
        }
    }
}

