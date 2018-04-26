using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    class Program
    {
        public static int column(double[,] mass)
        {
            int col = 0;
            double max = mass[0, 0];
            for(int i=0; i<mass.GetLength(0);i++)
                for(int j=0;j<mass.GetLength(1);j++)
                {
                    if(max<mass[i,j])
                    {
                        max = mass[i, j];
                        col = j;
                    }
                }
            return col;
        }
        public static void output(double[,] mas)
        {
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                    Console.Write("{0:f3} ", mas[i, j]);
                Console.WriteLine();
            }
        }
        public static double[,] del(double[,] mas)
        {
            int col = column(mas);
            double[,] outmas = new double[mas.GetLength(0), mas.GetLength(1)-1];
            for(int i=0;i< mas.GetLength(0); i++)
            {

                for (int j = 0; j < mas.GetLength(1); j++)
                    if (j != col)
                        if (j < col)
                            outmas[i, j] = mas[i, j];
                        else
                            outmas[i, j - 1] = mas[i, j];
            }
            return outmas;
        }

        static void Main(string[] args)
        {
            int n, m;
            Console.WriteLine("введите размерность двумерного массива");
            Console.WriteLine("введите n");
            n = Int32.Parse(Console.ReadLine());

            Console.WriteLine("введите m");
            m = Int32.Parse(Console.ReadLine());

            double[,] mas = new double[n, m];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    mas[i, j] = rnd.NextDouble();

            Console.WriteLine("Исходный массив");
            output(mas);
            Console.WriteLine("\nномер удаляемого столбца={0}\n", column(mas)+1);
            if (m <= 1)
                Console.WriteLine("массив не существует!");
            else
                output( del(mas));
            Console.ReadKey();

        }

    }
}
