using Tenis;
using Tenis.Configuracao;
using Tenis.Controlador;
using Tenis.Entidade;
using Tenis.Enum;
using Tenis.Factory;


public class Program
{

    //Essa versão antes era um while. Mudando para poder fazer mais fácil o teste de aceitação.
    public static void Main()
    {
        var primeiroJogador = new Jogador("Primeiro Jogador");
        var segundoJogador = new Jogador("Segundo Jogador");
        var partida = new Partida(primeiroJogador, segundoJogador);
        var placar = new PlacarFactory(partida);
        var controlador = new ControladorPartida(partida);

        var continuar = true;
        while (continuar)
        {
            placar.Imprimir();
            var comando = Console.ReadLine();

            if (int.TryParse(comando, out var escolha))
            {
                Acao acao = (Acao)escolha;
                controlador.Executar(acao);
            }
            else if (comando == Configuracoes.Saida)
            {
                continuar = false;
            }
        }
    }
}