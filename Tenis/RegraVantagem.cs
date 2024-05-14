namespace Tenis
{
    internal class RegraVantagem
    {
        public static bool Ativo(int pontosJogadorUm, int pontosJogadorDois) {return (pontosJogadorUm == Configuracoes.PontoDeuce && pontosJogadorDois == Configuracoes.PontoDeuce);

        } 
        public static bool Resolvido(int pontosJogadorUm, int pontosJogadorDois) => Math.Abs(pontosJogadorUm - pontosJogadorDois) == Configuracoes.MelhorDe;
    }
}
