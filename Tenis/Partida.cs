namespace Tenis
{
    internal class Partida(Jogador primeiroJogador, Jogador segundoJogador)
    {
        public Jogador PrimeiroPlayer { get; init; } = primeiroJogador;
        public Jogador SegundoPlayer { get; init; } = segundoJogador;

        //Lógica para definir quem saca primeiro de forma "randomica"
        private Jogador ProximoSaque = Random.Shared.Next(0, 1) == 0 ? primeiroJogador : segundoJogador;

        private readonly int[] Pontuacao = [0, 15, 30, 40];

        public void Imprimir()
        {
            Console.WriteLine("Placar de Tênis:");
            Console.WriteLine($"Jogador 1: {PrimeiroPlayer.Sets} sets, {PrimeiroPlayer.Games} games, { Pontuacao[PrimeiroPlayer.Pontos] } pontos no game atual");
            Console.WriteLine($"Jogador 2: {SegundoPlayer.Sets} sets, {SegundoPlayer.Games} games,  {Pontuacao[SegundoPlayer.Pontos] } pontos no game atual");
            Console.WriteLine($"Próximo saque: {ProximoSaque.Nome}");
        }

        public void Pontuar(Jogador jogador)
        {
            jogador.Pontos++;

            if (jogador.Pontos == Configuracoes.UltimoPonto)
                AdicionarGame(jogador);
        }

        private void AdicionarGame(Jogador jogador)
        {
            if (jogador.Games == Configuracoes.UltimoGame)
                PontuarSet(jogador);

            jogador.Games++;

            if(PrimeiroPlayer.Pontos == 40 && SegundoPlayer.Pontos == 40)
                ProximoSaque = (ProximoSaque == PrimeiroPlayer) ? SegundoPlayer : PrimeiroPlayer;

            PrimeiroPlayer.Pontos = 0;
            SegundoPlayer.Pontos = 0;

            ProximoSaque = (ProximoSaque == PrimeiroPlayer) ? SegundoPlayer : PrimeiroPlayer;
        }

        private void PontuarSet(Jogador jogador)
        {
            var set = jogador.Sets + 1;
            jogador.Sets++;

            if (set == Configuracoes.UltimoSet)
            {
                Imprimir();
                Console.WriteLine($"{jogador.Nome} venceu a partida!");
                Environment.Exit(0);
            }
            else
            {
                PrimeiroPlayer.Pontos = 0;
                SegundoPlayer.Pontos = 0;
                PrimeiroPlayer.Games = 0;
                SegundoPlayer.Games = 0;
            }
        }
    }
}