using Tenis.Enum;

namespace Tenis.Configuracao
{
    internal class Regras
    {
        public static bool AtivarDeuce(Jogador primeiroJogador, Jogador segundoJogador, Modo modo) => primeiroJogador.Pontuacao.Pontos == Configuracoes.PontoDeuce && segundoJogador.Pontuacao.Pontos == Configuracoes.PontoDeuce;
        public static bool AtivarTieBreak(Jogador primeiroJogador, Jogador segundoJogador, Modo modo) => primeiroJogador.Game.Games == Configuracoes.UltimoGameDoSet && segundoJogador.Game.Games == Configuracoes.UltimoGameDoSet;
    }
}
