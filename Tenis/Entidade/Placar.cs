using Tenis.Enum;

namespace Tenis.Entidade
{
    public class Placar(Partida partida)
    {
        private readonly int[] Pontuacao = [0, 15, 30, 40];

        public void Imprimir()
        {
            Console.WriteLine("Placar de Tênis:");

            if (partida.Modo == Modo.TieBreak)
            {
                Console.WriteLine($"Jogador 1: {partida.PrimeiroJogador.Set.Sets} sets, {partida.PrimeiroJogador.Game.Games} games, {partida.PrimeiroJogador.Pontuacao.Pontos} pontos no game atual");
                Console.WriteLine($"Jogador 2: {partida.SegundoJogador.Set.Sets} sets, {partida.SegundoJogador.Game.Games} games,  {partida.SegundoJogador.Pontuacao.Pontos} pontos no game atual");
            }
            else if (partida.Modo == Modo.Deuce)
            {
                Console.WriteLine($"Jogador 1: {partida.PrimeiroJogador.Set.Sets} sets, {partida.PrimeiroJogador.Game.Games} games, {(partida.PrimeiroJogador.Pontuacao.Pontos > 0 ? Deuce.Vantagem : Deuce.Deuce)} pontos no game atual");
                Console.WriteLine($"Jogador 2: {partida.SegundoJogador.Set.Sets} sets, {partida.SegundoJogador.Game.Games} games,   {(partida.SegundoJogador.Pontuacao.Pontos > 0 ? Deuce.Vantagem : Deuce.Deuce)} pontos no game atual");
            }
            else
            {
                Console.WriteLine($"Jogador 1: {partida.PrimeiroJogador.Set.Sets} sets, {partida.PrimeiroJogador.Game.Games} games, {Pontuacao[partida.PrimeiroJogador.Pontuacao.Pontos]} pontos no game atual");
                Console.WriteLine($"Jogador 2: {partida.SegundoJogador.Set.Sets} sets, {partida.SegundoJogador.Game.Games} games,  {Pontuacao[partida.SegundoJogador.Pontuacao.Pontos]} pontos no game atual");
            }

            Console.WriteLine($"Próximo saque: {partida.ProximoSaque.Nome}");
            Console.WriteLine($"Modo: {partida.Modo}");
            Console.WriteLine($"Opções:");
            Console.WriteLine($"Pontuar Jogador 1: 1");
            Console.WriteLine($"Pontuar Jogador 2: 2");
        }
    }
}
