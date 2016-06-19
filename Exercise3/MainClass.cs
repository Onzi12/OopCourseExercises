using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    class MainClass
    {

        public static object int_add(object x, object y)
        {
            int ix, iy, iz;

            ix = (int)x;
            iy = (int)y;
            iz = ix + iy;
            return ( (object)iz );
        } // int_add


        public static object int_sub(object x, object y)
        {
            int ix, iy, iz;

            ix = (int)x;
            iy = (int)y;
            iz = ix - iy;
            return ( (object)iz );
        } // int_sub




        public static object int_mul(object x, object y)
        {
            int ix, iy, iz;

            ix = (int)x;
            iy = (int)y;
            iz = ix * iy;
            return ( (object)iz );
        } // int_mul

        public static object double_add(object x, object y)
        {
            double dx, dy, dz;

            dx = (double)x;
            dy = (double)y;
            dz = dx + dy;
            return ( (double)dz );
        } // double_add


        public static object double_sub(object x, object y)
        {
            double dx, dy, dz;

            dx = (double)x;
            dy = (double)y;
            dz = dx - dy;
            return ( (double)dz );
        } // double_sub


        public static object double_mul(object x, object y)
        {
            double dx, dy, dz;

            dx = (double)x;
            dy = (double)y;
            dz = dx * dy;
            return ( (double)dz );
        } // double_mul


        static void Main()
        {
            int n = 5, i, j;
            Matrix<double> M1d = new Matrix<double>(n, double_add, double_sub, double_mul),
               M2d = new Matrix<double>(n, double_add, double_sub, double_mul),
                M3d = new Matrix<double>(n, double_add, double_sub, double_mul);
            double d;
            int k;

            for ( i = 0 ; i < M1d.N ; i++ )
                for ( j = 0 ; j < M1d.N ; j++ )
                {
                    M1d[i, j] = 1.1 * i + j;
                    M2d[i, j] = 10.1 * i + 1.1 * j;
                } // for

            Console.WriteLine("M1d:");
            M1d.print();
            Console.WriteLine("M2d:");
            M2d.print();

            Console.WriteLine("M1d + M2d:");
            M3d = M1d + M2d;
            M3d.print();
            M3d = M1d * M2d;
            Console.WriteLine("M1d * M2d:");
            M3d.print();

            d = (double)M1d;
            Console.WriteLine("\n(double)M1d = " + d);


            Matrix<int> M1i = new Matrix<int>(n, int_add, int_sub, int_mul),
               M2i = new Matrix<int>(n, int_add, int_sub, int_mul),
                M3i = new Matrix<int>(n, int_add, int_sub, int_mul);


            for ( i = 0 ; i < M1i.N ; i++ )
                for ( j = 0 ; j < M1i.N ; j++ )
                {
                    M1i[i, j] = i + 10 * j;
                    M2i[i, j] = 100 * i + 10 * j;
                } // for

            Console.WriteLine("\n\nM1i:");
            M1i.print();
            Console.WriteLine("M2i:");
            M2i.print();

            Console.WriteLine("M1i + M2i:");
            M3i = M1i + M2i;
            M3i.print();
            M3i = M1i * M2i;
            Console.WriteLine("M1i * M2i:");
            M3i.print();

            k = (int)M1i;
            Console.WriteLine("\n(int)M1i = " + k);

        } // Main

    }
}
