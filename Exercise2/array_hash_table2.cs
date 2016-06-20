using System;

namespace Exercise2
{
    internal class array_hash_table2 : array_hash_table
    {

        public sealed override ifunc Hash
        {
            get { return hash; }
        }

        public array_hash_table2(int arrSize, ifunc hash) : base(arrSize)
        {
            Hash = hash;
        }
    }
}