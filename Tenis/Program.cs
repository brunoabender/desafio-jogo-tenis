namespace Tenis
{
    internal class Program
    {
        static void Main()
        {
            var primeiroJogador = new Jogador("Primeiro Jogador");
            var segundoJogador = new Jogador("Segundo Jogador");

            var partida = new Partida(primeiroJogador, segundoJogador);
            
            var placar = new Placar(partida);
            var controlador = new Controlador(partida);

            while (true)
            {
                placar.Imprimir();
                var escolha = Console.ReadLine();
                if(string.IsNullOrEmpty(escolha)) 
                    Console.WriteLine("Escolha uma opção!"); 
                else
                    controlador.Acao(escolha);
            }
        }
    }
}
