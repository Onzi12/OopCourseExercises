using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    internal class new_hash
    {
        public static int alt_hash_fun(int x, int n)
        {
            return ( x * x ) % n;

        } // alt_hash_fun

    } //  new_hash


    internal class MainClass
    {
        public static int Main()
        {
            array_hash_table My_table = new array_hash_table(7);

            My_table.insert(39);
            My_table.insert(5);
            My_table.insert(23);
            My_table.insert(9);
            My_table.insert(3);
            My_table.insert(2);


            Console.WriteLine("\nIs member {0} = {1}", 23L, My_table.is_member(23));
            Console.WriteLine("\nIs member {0} = {1}", 39L, My_table.is_member(39));
            Console.WriteLine("\nIs member {0} = {1}", 40L, My_table.is_member(40));

            ifunc new_hash_fun = new ifunc(new_hash.alt_hash_fun);

            array_hash_table2 My_table2 = new array_hash_table2(9, new_hash_fun);

            My_table2.insert(39);
            My_table2.insert(5);
            My_table2.insert(23);
            My_table2.insert(9);
            My_table2.insert(3);
            My_table2.insert(2);


            Console.WriteLine("\nIs member {0} = {1}", 23L, My_table2.is_member(23));
            Console.WriteLine("\nIs member {0} = {1}", 39L, My_table2.is_member(39));
            Console.WriteLine("\nIs member {0} = {1}", 40L, My_table2.is_member(40));

            return 0;

        } // main
    }

// MainClass

}
