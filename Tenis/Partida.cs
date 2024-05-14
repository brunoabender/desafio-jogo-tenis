namespace Tenis
{
    public class Partida
    {
        public Jogador PrimeiroJogador { get; private set; }
        public Jogador SegundoJogador { get; private set; }
        public Jogador ProximoSaque { get; private set; }
        public Modo Modo { get; set; } = Modo.Normal;

        public Partida(Jogador primeiroJogador, Jogador segundoJogador)
        {
            PrimeiroJogador = primeiroJogador;
            SegundoJogador = segundoJogador;
            ProximoSaque = new Random().Next(0, 2) == 0 ? primeiroJogador : segundoJogador;
        }

        public void Pontuar(Jogador jogador)
        {
            jogador.Pontuacao.AdicionarPonto();
            if (jogador.Pontuacao.Pontos == Configuracoes.UltimoPontoGame)
            {
                PontuarGame(jogador);
            }
        }

        private void PontuarGame(Jogador jogador)
        {
            jogador.Game.Adicionar();
            if (jogador.Game.Games == Configuracoes.UltimoGameDoSet)
                PontuarSet(jogador);
            
            LimparPontuacao();
            SelecionarProximoSaque();
        }

        private void PontuarSet(Jogador jogador)
        {
            jogador.Set.Adicionar();
            if (jogador.Set.Sets == Configuracoes.UltimoSet)
            {
                Console.WriteLine($"{jogador.Nome} venceu a partida!");
                Environment.Exit(0);
            }
            else
            {
                LimparPontuacao();
                LimparGames();
            }
        }

        private void LimparPontuacao()
        {
            PrimeiroJogador.Pontuacao.Resetar();
            SegundoJogador.Pontuacao.Resetar();
        }

        private void LimparGames()
        {
            PrimeiroJogador.Game.Resetar();
            SegundoJogador.Game.Resetar();
        }

        private void SelecionarProximoSaque() => ProximoSaque = (ProximoSaque == PrimeiroJogador) ? SegundoJogador : PrimeiroJogador;

        public void NovoJogo()
        {
            PrimeiroJogador = new Jogador("Primeiro Jogador");
            SegundoJogador = new Jogador("Segundo Jogador");
        }
    }
}