using System;

namespace Exercise3
{
    internal class Matrix<T>
    {
        T[,] matrix;
        private int n;

        public Matrix(
                      int n, 
                      Func<object, object, object> addition, 
                      Func<object, object, object> substrection, 
                      Func<object, object, object> doubleMul)
        {
            N = n;
            matrix = new T[N,N];

        }

        public int N
        {
            get { return n; }
            private set { n = value; }
        }

        public T this[int i, int j]
        {
            get { return matrix[i,j]; }
            set { matrix[i,j] = value; }
        }

        public void print()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(matrix[i,j] + "  ");
                }
                Console.WriteLine();
            }
        }

        public static Matrix<T> operator +(Matrix<T> x, Matrix<T> y)
        {
            var result = new Matrix<T>(x.N, null, null, null); //TODO: Fix me
            return result;
        }

        public static Matrix<T> operator *(Matrix<T> x, Matrix<T> y)
        {
            var result = new Matrix<T>(x.N, null, null, null); //TODO: Fix me
            return result;
        }
    }
}