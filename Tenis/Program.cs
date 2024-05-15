using Tenis;
using Tenis.Controlador;
using Tenis.Entidade;
using Tenis.Enum;
using Tenis.Factory;

var primeiroJogador = new Jogador("Primeiro Jogador");
var segundoJogador = new Jogador("Segundo Jogador");
var partida = new Partida(primeiroJogador, segundoJogador);
var placar = new PlacarFactory(partida);
var controlador = new Controlador(partida);

while (true)
{
    placar.Imprimir();
    var comando = Console.ReadLine();

    if(int.TryParse(comando, out var escolha))
    {
        Acao acao = (Acao)escolha;
        controlador.Executar(acao);
    }
}
