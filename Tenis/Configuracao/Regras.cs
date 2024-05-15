namespace Tenis.Configuracao
{
    internal class Regras
    {
        public static bool EstaEmDeuce(Jogador primeiroJogador, Jogador segundoJogador) => primeiroJogador.Pontuacao.Pontos == Configuracoes.PontoDeuce && segundoJogador.Pontuacao.Pontos == Configuracoes.PontoDeuce;
        public static bool EstaEmTieBreak(Jogador primeiroJogador, Jogador segundoJogador) => primeiroJogador.Game.Games == Configuracoes.UltimoGameDoSet - 1 && segundoJogador.Game.Games == Configuracoes.UltimoGameDoSet - 1;
    }
}
