using Tenis.Configuracao;

namespace Tenis.Comum
{
    internal class CalculoDiferenca
    {
        public static bool PermitirPontuar(int ponto, int pontoAdversario) => Math.Abs(ponto - pontoAdversario) >= Configuracoes.MelhorDe;
        
    }
}
