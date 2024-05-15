namespace Tenis.Entidade
{
    public class Game
    {
        public int Games { get; private set; } = 5;
        public void Adicionar() => Games++;
        public void Resetar() => Games = 0;
    }
}