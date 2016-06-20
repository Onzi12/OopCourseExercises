using System;

namespace Exercise3
{
    internal class Matrix<T>
    {
        private readonly T[,] matrix;

        public int N { get; } // can be assigned only in a constructor

        private readonly Func<object, object, object> addition;
        private readonly Func<object, object, object> substraction;
        private readonly Func<object, object, object> multiplication;

        public Matrix(
            int n, 
            Func<object, object, object> addition, 
            Func<object, object, object> substraction, 
            Func<object, object, object> multiplication)
        {
            N = n;
            matrix = new T[N,N];
            this.addition = addition;
            this.substraction = substraction;
            this.multiplication = multiplication;
        }

        // Add two objects of type T 
        public void print()
        {
            for ( int i = 0 ; i < N ; i++ )
            {
                for ( int j = 0 ; j < N ; j++ )
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        private T TtypeAddition(T x, T y)
        {
            return (T) addition(x, y);
        }

        // Subtract two objects of type T 
        private T TtypeSubstraction(T x, T y)
        {
            return (T) substraction(x, y);
        }

        // Multiply two objects of type T
        private T TtypeMultiplication(T x, T y)
        {
            return (T) multiplication(x, y);
        }

        #region operators

        // the indexer
        public T this[int i, int j]
        {
            get { return matrix[i,j]; }
            set { matrix[i,j] = value; }
        }

        // Matrix Addition
        public static Matrix<T> operator +(Matrix<T> x, Matrix<T> y)
        {
            var result = new Matrix<T>(x.N, x.addition, x.substraction, x.multiplication);

            for (int i = 0; i < x.N; i++)
            {
                for (int j = 0; j < x.N; j++)
                {
                    result[i, j] = result.TtypeAddition(x[i, j], y[i, j]);
                }
            }
            return result;
        }

        // Matrix Subtraction
        public static Matrix<T> operator -(Matrix<T> x, Matrix<T> y)
        {
            var result = new Matrix<T>(x.N, x.addition, x.substraction, x.multiplication);

            for ( int i = 0 ; i < x.N ; i++ )
            {
                for ( int j = 0 ; j < x.N ; j++ )
                {
                    result[i, j] = result.TtypeSubstraction(x[i, j], y[i, j]);
                }
            }
            return result;
        }

        // Matrix Multiplication
        public static Matrix<T> operator *(Matrix<T> x, Matrix<T> y)
        {
            var result = new Matrix<T>(x.N, x.addition, x.substraction, x.multiplication);

            for ( int i = 0 ; i < x.N ; i++ )
            {
                for ( int j = 0 ; j < x.N ; j++ )
                {
                    T res = default(T);
                    for (int k = 0; k < x.N; k++)
                    {
                        res = result.TtypeAddition(result.TtypeMultiplication(x[i, k], y[k, j]), res);
                    }
                    result[i, j] = res;
                }
            }

            return result;
        }

        // Explicit cast to type T
        public static explicit operator T(Matrix<T> matrix)
        {
            T sum = default(T);
            foreach (var t in matrix.matrix)
            {
                sum = matrix.TtypeAddition(t, sum);
            }
            return sum;
        }
#endregion operators
    }
}