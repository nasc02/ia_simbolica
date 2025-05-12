
namespace LabirintoRobo.Models
{
    public class Robo
    {
        public string Nome { get; private set; }
        public int Energia { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Robo(string nome, int energia, int x, int y)
        {
            Nome = nome;
            Energia = energia;
            X = x;
            Y = y;
        }
    }
}
