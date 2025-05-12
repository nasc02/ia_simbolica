
using LabirintoRobo.Models;
using System;
using System.Collections.Generic;

namespace LabirintoRobo.Util
{
    public class ClasseDeUtilidade
    {
        public class Celula
        {
            public string Nome { get; set; }
            public TipoDePosicao Tipo { get; set; }

            public Celula(string nome, TipoDePosicao tipo)
            {
                Nome = nome;
                Tipo = tipo;
            }
        }

        public Celula[,] matriz = new Celula[10, 10];
        private Random random = new Random();

        public void GerarMatrizAleatoria()
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    matriz[i, j] = new Celula($"I{{{i}}}J{{{j}}}", TipoDePosicao.Normal);

            GerarTipoAleatorio(5, TipoDePosicao.Energia5);
            GerarTipoAleatorio(3, TipoDePosicao.Energia10);
            GerarTipoAleatorio(random.Next(20) + 15, TipoDePosicao.Obstaculo);
        }

        private void GerarTipoAleatorio(int quantidade, TipoDePosicao tipo)
        {
            int count = 0;
            while (count < quantidade)
            {
                int i = random.Next(10);
                int j = random.Next(10);
                if ((i == 0 && j == 0) || (i == 9 && j == 9))
                    continue;

                if (matriz[i, j].Tipo == TipoDePosicao.Normal)
                {
                    matriz[i, j].Tipo = tipo;
                    count++;
                }
            }
        }

        public void ImprimirMatriz()
        {
            Console.WriteLine("\nMatriz:");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    switch (matriz[i, j].Tipo)
                    {
                        case TipoDePosicao.Normal:
                            Console.Write(" . ");
                            break;
                        case TipoDePosicao.Obstaculo:
                            Console.Write(" X ");
                            break;
                        case TipoDePosicao.Energia5:
                            Console.Write(" + ");
                            break;
                        case TipoDePosicao.Energia10:
                            Console.Write("++ ");
                            break;
                        default:
                            Console.Write(" ? ");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        public int MoverRobo(Robo robo)
        {
            int[] dx = { -1, 1, 0, 0 }; // cima, baixo
            int[] dy = { 0, 0, -1, 1 }; // esquerda, direita

            Queue<(int x, int y, int energia, List<string> caminho)> fila = new();
            fila.Enqueue((robo.X, robo.Y, robo.Energia, new List<string> { $"({robo.X},{robo.Y})" }));
            bool[,] visitado = new bool[10, 10];
            visitado[robo.X, robo.Y] = true;

            while (fila.Count > 0)
            {
                var atual = fila.Dequeue();
                int x = atual.x, y = atual.y, energia = atual.energia;
                List<string> caminho = atual.caminho;

                if (x == 9 && y == 9)
                {
                    Console.WriteLine("\n Caminho percorrido:");
                    Console.WriteLine(string.Join(" -> ", caminho));
                    robo.X = x;
                    robo.Y = y;
                    robo.Energia = energia;
                    return energia;
                }

                for (int d = 0; d < 4; d++)
                {
                    int nx = x + dx[d];
                    int ny = y + dy[d];

                    if (nx >= 0 && nx < 10 && ny >= 0 && ny < 10 && !visitado[nx, ny] && PodeAndar(matriz[nx, ny].Tipo))
                    {
                        int novaEnergia = energia - Custo(matriz[nx, ny].Tipo);
                        if (novaEnergia > 0)
                        {
                            List<string> novoCaminho = new List<string>(caminho) { $"({nx},{ny})" };
                            fila.Enqueue((nx, ny, novaEnergia, novoCaminho));
                            visitado[nx, ny] = true;
                        }
                    }
                }
            }

            Console.WriteLine("Não foi possível chegar até o destino!");
            return 0;
        }

        private bool PodeAndar(TipoDePosicao tipo)
        {
            return tipo != TipoDePosicao.Obstaculo && tipo != TipoDePosicao.PosicaoNaoVisitavel;
        }

        private int Custo(TipoDePosicao tipo)
        {
            return tipo switch
            {
                TipoDePosicao.Normal => 1,
                TipoDePosicao.Energia5 => -5,
                TipoDePosicao.Energia10 => -10,
                _ => 5,
            };
        }
    }
}
