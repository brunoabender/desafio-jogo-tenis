namespace Tenis
{
    internal class Program
    {
        static void Main()
        {
            var primeiroJogador = new Jogador { Nome = "Primeiro Jogador" };
            var segundoJogador = new Jogador { Nome = "Segundo Jogador" };

            var partida = new Partida(primeiroJogador, segundoJogador);
            var placar = new Placar(partida);

            while (true)
            {
                placar.Imprimir();
                var resultado = Console.ReadLine();

                if (resultado == "1")
                    partida.Pontuar(partida.PrimeiroJogador);
                else if (resultado == "2")
                    partida.Pontuar(partida.SegundoJogador);
                else if(resultado == "n")
                    partida.NovoJogo();
            }
        }
    }
}
