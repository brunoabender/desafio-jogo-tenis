using Tenis.Entidade;
using Tenis.Enum;
using Tenis.Placar;

namespace Tenis.Factory
{
    public class PlacarFactory(Partida partida)
    {
        public void Imprimir()
        {

            switch (partida.Modo)
            {
                case Modo.TieBreak:
                     new PlacarTieBreak().Obter(partida);
                    break;
                case Modo.Deuce:
                    new PlacarDeuce().Obter(partida);
                    break;
                default:
                    new PlacarNormal().Obter(partida);
                    break;
            }
        }
    }
}
