
using Tenis.Entidade;
using Tenis.Enum;

namespace Tenis.Placar
{
    internal class PlacarDeuce : IPlacar
    {
        public void Obter(Partida partida)
        {
            Console.WriteLine("Placar de Tênis:");
            Console.WriteLine($"Jogador 1: {partida.PrimeiroJogador.Set.Sets} sets, {partida.PrimeiroJogador.Game.Games} games, {(partida.PrimeiroJogador.Pontuacao.Pontos > 0 ? Deuce.Vantagem : Deuce.Deuce)} pontos no game atual");
            Console.WriteLine($"Jogador 2: {partida.SegundoJogador.Set.Sets} sets, {partida.SegundoJogador.Game.Games} games,   {(partida.SegundoJogador.Pontuacao.Pontos > 0 ? Deuce.Vantagem : Deuce.Deuce)} pontos no game atual");
            Console.WriteLine($"Próximo saque: {partida.ProximoSaque.Nome}");
            Console.WriteLine($"Modo: {partida.Modo}");
            Console.WriteLine($"Opções:");
            Console.WriteLine($"Pontuar Jogador 1: 1");
            Console.WriteLine($"Pontuar Jogador 2: 2");
        }
    }
}
