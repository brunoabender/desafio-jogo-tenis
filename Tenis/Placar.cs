namespace Tenis
{
    public class Placar(Partida partida) 
    {
        private readonly int[] Pontuacao = [0, 15, 30, 40];

        public void Imprimir()
        {
            Console.WriteLine("Placar de Tênis:");
            Console.WriteLine($"Jogador 1: {partida.PrimeiroJogador.Set.Sets} sets, {partida.PrimeiroJogador.Game.Games} games, {Pontuacao[partida.PrimeiroJogador.Pontuacao.Pontos]} pontos no game atual");
            Console.WriteLine($"Jogador 2: {partida.SegundoJogador.Set.Sets} sets, {partida.SegundoJogador.Game.Games} games,  {Pontuacao[partida.SegundoJogador.Pontuacao.Pontos]} pontos no game atual");
            Console.WriteLine($"Próximo saque: {partida.ProximoSaque.Nome}");
        }
    }
}
