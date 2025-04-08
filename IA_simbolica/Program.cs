using ia_simbolica;
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {
        GeneralPurposeClass g = new GeneralPurposeClass();

        int[,] matriz = new int[10, 10];
        int robo = 99; //numero aleatorio acima de 20
        int energia = 50;

        //possiveis movimentos
        // [i-1, j] -> cima
        // [i+1, j] -> baixo
        // [i, j+1] -> direita
        // [i-1, j-1] -> esquerda

        //matriz ex
        //0 0 1 2 3 4 5 6 7 8 9
        //1 0 1 2 3 4 5 6 7 8 9
        //2 0 1 2 3 4 5 6 7 8 9
        //3 0 1 2 3 4 5 6 7 8 9
        //4 0 1 2 3 4 5 6 7 8 9
        //5 0 1 2 3 4 5 6 7 8 9
        //6 0 1 2 3 4 5 6 7 8 9
        //7 0 1 2 3 4 5 6 7 8 9
        //8 0 1 2 3 4 5 6 7 8 9
        //9 0 1 2 3 4 5 6 7 8 9
        //matriz fixa para teste esboço inicial
        //estou utilizando um numero randomico ate 20 pensando que talvez possamos usar alguns numero fixos para representar posições obscuras
        matriz = g.GerarMatrizAleatoria();
        List<int> obscurePositionsRepresentative = new List<int> { 5, 10, 15, 20 };

        energia -= g.AcheOMelhorCaminhoParaORobo(matriz, robo);

        Console.WriteLine($"energia final do robo no teste  {energia}");

        //teste de movimento supondo o caminho perfeito




    }

}