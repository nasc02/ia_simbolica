using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IA_simbolica.models;

namespace ia_simbolica
{
    public class GeneralPurposeClass
    {

        public KeyValuePair<string, TypeOfPosition>[,] matriz { get; } = new KeyValuePair<string, TypeOfPosition>[10, 10];
        public GeneralPurposeClass() { }

        public int AcheOMelhorCaminhoParaORobo(KeyValuePair<string, TypeOfPosition>[,] matriz, Robot robot) {
            //TODO: Implementar o algoritmo de busca do melhor caminho para o robô
            int energiaGasta = 0;
            int matrixLengthY = matriz.GetLength(0);
            int matrixLengthX = matriz.GetLength(1);


            return energiaGasta;
        }


        public void GerarMatrizAleatoria()
        {
            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {

                for (int j = 0; j < 10; j++)
                {
                    matriz[i, j] = new KeyValuePair<string, TypeOfPosition>(@$"I{{{i}}}J{{{j}}}", TypeOfPosition.Normal);

                }
            }

            generatDynamicMatrizPositions(r, 5, TypeOfPosition.gainEnergy5);
            generatDynamicMatrizPositions(r, 3, TypeOfPosition.gainEnergy10);
            generatDynamicMatrizPositions(r, r.Next(15, 35), TypeOfPosition.Obscure);
        }
    

        public void PrintMatrix()
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {

                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write(matriz[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        public void generatDynamicMatrizPositions(Random r, int runTimes, TypeOfPosition typeOfPosition){
            
            if(runTimes > 0){
                int randomPositionI = r.Next(0, 10);
                int randomPositionJ = r.Next(0, 10);

                bool isProtectedPosition = (randomPositionI == 0 && randomPositionJ == 0) || (randomPositionI == 9 && randomPositionJ == 9);

                if(matriz[randomPositionI, randomPositionJ].Value == TypeOfPosition.Normal && !isProtectedPosition){
                    matriz[randomPositionI, randomPositionJ] = new KeyValuePair<string, TypeOfPosition>(@$"I{{{randomPositionI}}}J{{{randomPositionJ}}}", typeOfPosition);
                    generatDynamicMatrizPositions(r, runTimes-1, typeOfPosition);
                }else{
                    generatDynamicMatrizPositions(r, runTimes, typeOfPosition);
                };
            }
        }

 }
}
