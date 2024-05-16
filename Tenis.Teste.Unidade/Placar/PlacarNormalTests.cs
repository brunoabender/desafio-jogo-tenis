﻿using FluentAssertions;
using Tenis.Entidade;
using Tenis.Placar;
using Xunit;

namespace Tenis.Teste.Unidade.Placar
{
    [Collection("RecursoCompartilhado")]
    public class PlacarNormalTests
    {
        [Fact]
        public void DeveImprimirPlacarNormalCorretamente()
        {
            var primeiroJogador = new Jogador("Jogador 1")
            {
                Set = new Set(1),
                Game = new Game(1),
                Pontuacao = new Pontuacao(1)
            };

            var segundoJogador = new Jogador("Jogador 2")
            {
                Set = new Set(1),
                Game = new Game(2),
                Pontuacao = new Pontuacao(2)
            };


            // Arrange
            var partida = new Partida(primeiroJogador, segundoJogador);
            var placarDeuce = new PlacarNormal();

            using var stringWritter = new StringWriter();
            Console.SetOut(stringWritter);

            // Act
            placarDeuce.Obter(partida);

            // Assert
            var resultado = stringWritter.ToString().Trim();
            resultado.Should().Contain("Placar de Tênis:");
            resultado.Should().Contain("Jogador 1: 1 sets, 1 games, 15 pontos no game atual");
            resultado.Should().Contain("Jogador 2: 1 sets, 2 games, 30 pontos no game atual");
            resultado.Should().Contain("Próximo saque: Jogador 1");
            resultado.Should().Contain("Modo: Normal");
        }
    }
}
