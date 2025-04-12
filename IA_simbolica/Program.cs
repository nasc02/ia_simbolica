using ia_simbolica;
using IA_simbolica.models;
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {
        GeneralPurposeClass g = new GeneralPurposeClass();

        // KeyValuePair<string, TypeOfPosition>[,] matriz = new KeyValuePair<string, TypeOfPosition>[10, 10];
        Robot robo = new Robot(name: "robocop", energy: 50, positionX: 0, positionY: 0)	; //numero aleatorio acima de 20
        Console.WriteLine($"robo {robo.Name} criado com energia {robo.Energy} e posição {robo.PositionX}, {robo.PositionY}");

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
        g.GerarMatrizAleatoria();
        g.PrintMatrix();
        // List<int> obscurePositionsRepresentative = new List<int> { 5, 10, 15, 20, 25, 30, 35 };
        // List<int> oPositionsRepresentative = new List<int> { 5, 10, 15, 20, 25, 30, 35 };

        int energia = g.AcheOMelhorCaminhoParaORobo(g.matriz, robo);

        Console.WriteLine($"energia final do robo no teste  {energia}");

    }

}