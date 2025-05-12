using LabirintoRobo.Models;
using LabirintoRobo.Util;
using System;

namespace LabirintoRobo
{
    class Program
    {
        static void Main(string[] args)
        {
            ClasseDeUtilidade util = new ClasseDeUtilidade();
            Robo robo = new Robo("Robocop", 50, 0, 0);

            Console.WriteLine($" Robô {robo.Nome} criado com energia {robo.Energia} na posição ({robo.X},{robo.Y})");

            util.GerarMatrizAleatoria();
            util.ImprimirMatriz();

            int energiaFinal = util.MoverRobo(robo);
            Console.WriteLine($"Energia final do robô: {energiaFinal}");
        }
    }
}
