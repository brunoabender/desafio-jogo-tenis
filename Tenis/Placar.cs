namespace Tenis
{
    public class Placar(Partida partida) 
    {
        private readonly int[] Pontuacao = [0, 15, 30, 40];

        public void Imprimir()
        {
            Console.WriteLine("Placar de Tênis:");
            Console.WriteLine($"Jogador 1: {partida.PrimeiroJogador.Sets} sets, {partida.PrimeiroJogador.Games} games, {Pontuacao[partida.PrimeiroJogador.Pontos]} pontos no game atual");
            Console.WriteLine($"Jogador 2: {partida.SegundoJogador.Sets} sets, {partida.SegundoJogador.Games} games,  {Pontuacao[partida.SegundoJogador.Pontos]} pontos no game atual");
            Console.WriteLine($"Próximo saque: {partida.ProximoSaque.Nome}");
        }
    }
}
