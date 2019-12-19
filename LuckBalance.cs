using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many contests Lena will participate? ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many of important contests Lena can lose?");
            int k = Convert.ToInt32(Console.ReadLine());

            int[] luckArray = new int[n];
            int[] importantArray = new int[n];
            int importantCount = 0;
            int lessLuck = 0;
            int mostLuck = 0;
            int lessLuckPosition = 0;

            for (int i = 0; i<n; i++)
            {
                Console.WriteLine($"Type the luck of the {i + 1} contest: ");
                luckArray[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Are the {i+1} constest importante? 1 for yes, 0 for no");
                importantArray[i] = Convert.ToInt32(Console.ReadLine());

                //aqui é setado uma variavel mostluck para conter o maior valor de luck recebido
                if(mostLuck <= luckArray[i])
                {
                    mostLuck = luckArray[i];
                }

                //aqui server para contar quantos concursos sao importantes
                if(importantArray[i] == 1)
                {
                    importantCount += 1;
                }
            }

            //variavel para contar os concursos que vao ser faltados
            int count = 0;
            
            //(importantCount - k) é quantos concusos vao ser faltados
            while (count < importantCount -k)
            {
                //aqui sempre a less luck vai ser a maior, a fim de sempre 
                //ser a menor depois de percorrer todo array
                lessLuck = mostLuck;
                for (int i =0; i<luckArray.Length; i++)
                {
                    if(lessLuck >= luckArray[i] && importantArray[i] == 1)
                    {
                        lessLuckPosition = i;
                        lessLuck = luckArray[i];
                    }
                }
                luckArray[lessLuckPosition] = -luckArray[lessLuckPosition];
                importantArray[lessLuckPosition] = 0;
                count += 1;
            }

            int totalAmount = 0;

            for(int i = 0; i< luckArray.Length; i++)
            {
                totalAmount = totalAmount + luckArray[i];
            }

            Console.WriteLine(totalAmount);

            Console.ReadKey();
        }
    }
}
