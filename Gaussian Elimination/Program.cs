using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaussian_EliminationC__
{



    public class Matrix
    {
        public double[,] data;

        public int NbRows
        {
            get;
            private set;
        }

        public int NbCols
        {
            get;
            private set;
        }

        public double this[int i, int j]
        {
            get
            {
                return data[i, j];
            }
            set
            {
                data[i, j] = value;
            }
        }

        public Matrix(int m, int n)
        {
           
            NbRows = m;
            NbCols = n;

            data = new double[m, n];
            
        }

        public double[,] FillMatrix()
        {
            for (int i = 0; i < NbRows; i++)
            {
                for (int j = 0; j < NbCols; j++)
                {
                    Console.Write($"Input m[{i}][{j}]: ");
                    data[i,j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            return data;
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < NbRows; i++)
            {
                for (int j = 0; j < NbCols; j++)
                {
                    Console.Write(String.Format("{0,5}", data[i, j]));
                }
                Console.Write("\n");
            }
        }

        public double[,] SwapRow(int k, int i)
        {
            for (int l = 0; l < NbCols; l++)
            {
                double temp = data[i,l];
                data[i,l] = data[k,l];
                data[k,l] = temp;
            }
            return data;
        }

        public int MaxInColum(int index)
        {
            int matr_MaxIndex = 0;
            double Max = data[index,index];
            for (int i = index + 1; i < NbRows; i++)
            {
                if (Math.Abs(data[i,index]) > Math.Abs(Max))
                {
                    Max = data[i,index];
                    matr_MaxIndex = i;
                }
            }
            return matr_MaxIndex;
        }
    }

    class Program
    {


        

        
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Matrix matrix = new Matrix(n,n+1);

            matrix.FillMatrix();
            matrix.PrintMatrix();
            for (int k = 0; k < n-1; k++)
            {
                int row_index_with_max_elem = matrix.MaxInColum(k); 
                matrix.SwapRow(k, row_index_with_max_elem);
                for (int i = k + 1; i < n; i++)
                {
                    double m = (-1) * (matrix[i, k]) / (matrix[k, k]);
                    for (int j = k; j < n+1; j++)
                    {
                        matrix[i,j] = matrix[i,j] + m * matrix[k,j];
                    }
                }
            }


            double[] x =new double[n];
            for(int k = n-1; k >= 0; k--)
            {
                double s = 0;
                for (int j = k; j <n; j++)
                {
                    s += matrix[k, j] * x[j];
                }

                x[k] = (matrix[k,n] - s) / matrix[k, k];
            }

            
            Console.WriteLine("\n");

            matrix.PrintMatrix();

            Console.WriteLine("\n");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"X:{x[i]}");
            }

            double matrixDet = 1;
            for (int i = 0; i < matrix.NbRows; i++)
            {
                for (int j = 0; j < matrix.NbCols; j++)
                {
                    if (i == j)
                        matrixDet *= matrix[i, j];
                }
            }
            Console.WriteLine($"\nMatrix det:{matrixDet}");

        }
    }
}
