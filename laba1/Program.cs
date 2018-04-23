using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    class Program
    {
        public static int column(double[,] mass, int n,int m)
        {
            int col = 0;
            double max = mass[0, 0];
            for(int i=0; i<n;i++)
                for(int j=0;j<m;j++)
                {
                    if(max<mass[i,j])
                    {
                        max = mass[i, j];
                        col = j;
                    }
                }
            return col;
        }
        public static void output(double[,] mas, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write("{0:f3} ", mas[i, j]);
                Console.WriteLine();
            }
        }
        public static double[,] del(double[,] mas,int n,int m)
        {
            int col = column(mas, n, m);
            for(int i=0;i<n; i++)
            {

                for (int j = 0; j < m; j++)
                    if (j != col)
                        if (j < col)
                            mas[i, j] = mas[i, j];
                        else
                            mas[i, j - 1] = mas[i, j];
            }
            return mas;
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
            output(mas, n, m);
            Console.WriteLine("\nномер удаляемого столбца={0}\n", column(mas, n, m)+1);
            output( del(mas, n, m), n, m-1);
            Console.ReadKey();

        }

    }
}
