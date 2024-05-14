namespace Tenis
{
    internal class Program
    {
        static void Main()
        {
            var primeiroJogador = new Jogador { Nome = "Primeiro Jogador" };
            var segundoJogador = new Jogador { Nome = "Segundo Jogador" };
            var partida = new Partida(primeiroJogador, segundoJogador);
            var placar = new Placar(primeiroJogador, segundoJogador);

            while (true)
            {
                placar.Imprimir();
                var resultado = Console.ReadLine();

                if (resultado == "1")
                    partida.Pontuar(partida.PrimeiroPlayer);
                else if (resultado == "2")
                    partida.Pontuar(partida.SegundoPlayer);
                else if(resultado == "n")
                    partida.NovoJogo();
            }
        }
    }
}
