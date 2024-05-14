namespace Tenis
{
    internal static class RegraVantagem
    {
        public static bool Ativo(int pontosJogadorUm, int pontosJogadorDois) => (pontosJogadorUm == Configuracoes.UltimoPontoDeuce && pontosJogadorDois == Configuracoes.UltimoPontoDeuce);
        public static bool Resolvido(int pontosJogadorUm, int pontosJogadorDois) => Math.Abs(pontosJogadorUm - pontosJogadorDois) == Configuracoes.DiferencaParaVantagem;
    }
}
