namespace Tenis.Entidade
{
    public class Game
    {
        public Game(int games)
        {
            Games = games;
        }   

        public int Games { get; private set; } = 4;
        public void Adicionar() => Games++;
        public void Resetar() => Games = 0;
    }
}