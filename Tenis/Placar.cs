namespace Tenis
{
    internal class Placar(Jogador primeiroJogador, Jogador segundoJogador) 
    {
        private readonly int[] Pontuacao = [0, 15, 30, 40];

        public void Imprimir()
        {
            Console.WriteLine("Placar de Tênis:");
            Console.WriteLine($"Jogador 1: {primeiroJogador.Sets} sets, {primeiroJogador.Games} games, {Pontuacao[primeiroJogador.Pontos]} pontos no game atual");
            Console.WriteLine($"Jogador 2: {segundoJogador.Sets} sets, {segundoJogador.Games} games,  {Pontuacao[segundoJogador.Pontos]} pontos no game atual");
            //Console.WriteLine($"Próximo saque: {JogadorSaque.Nome}");
        }
    }
}
