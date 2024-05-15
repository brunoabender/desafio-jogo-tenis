namespace Tenis
{
    public class Set
    {
        public Set (int sets)
        {
            Sets = sets;
        }

        public int Sets { get; private set; } = 0;
        public void Adicionar() => Sets++;
    }
}