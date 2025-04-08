using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ia_simbolica
{
    public class GeneralPurposeClass
    {
        public GeneralPurposeClass() { }

        public int AcheOMelhorCaminhoParaORobo(int[,] matriz, int robo) {
            int energiaGasta = 0;
            int m0length = matriz.GetLength(0);
            int m1length = matriz.GetLength(1);

            //posição inicial do robo é sempre [0,0]
            int x = 0, y = 0;

            //supondo matriz perfeita inicialmente
            while (x < m0length - 1) // se movendo para baixo até a última linha
            {
                x++;
                energiaGasta++;
            }

            while (y < m1length - 1) // se movendo para a direita até a última coluna
            {
                y++;
                energiaGasta++;
            }

            return energiaGasta;
        }


        public int[,] GerarMatrizAleatoria()
        {
            Random r = new Random();

            int[,] matriz = new int[10, 10];

            for (int i = 0; i < 10; i++)
            {
                matriz[i, 0] = r.Next(20);

                Console.Write(matriz[i, 0] + " ");

                for (int j = 0; j < 10; j++)
                {
                    matriz[i, j] = r.Next(20);
                    Console.Write(matriz[i, j] + " ");

                }

                Console.WriteLine();

            }

            return matriz;
        }
    }
}
