namespace Tenis
{
    internal class Controlador(Partida partida)
    {
        private readonly Partida partida = partida;

        public void Acao(string comando)
        {
            switch(comando)
            {
                case "1":
                    partida.Pontuar(partida.PrimeiroJogador);
                    break;
                case "2":
                    partida.Pontuar(partida.SegundoJogador);
                    break;
                case "n":
                    partida.NovoJogo();
                    break;
            }   
        }
    }
}
