using System;

namespace Exercise2
{
    internal class array_hash_table : hash_table_interface
    {
        private readonly int[] arr;
        protected ifunc hash;
        private const int HashEmptyCell = -1;
        private readonly int n;

        public array_hash_table(int n)
        {
            this.n = n;
            arr = new int[n*2 + 1]; // +1 : last cell is always HashEmptyCell to indicate EOT (End Of Table)
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = HashEmptyCell;
            }
        }

        public void insert(int number)
        {
            if (is_member(number))
            {
                return;
            }

            int insertIndex = Hash(number, n);

            while (arr[insertIndex] != HashEmptyCell)
            {
                ++insertIndex;
            }

            if (insertIndex < n)
            {
                arr[insertIndex] = number;
            }
        }

        public bool is_member(int number)
        {
            int i = Hash(number, n);
            while (arr[i] != HashEmptyCell)
            {
                if (arr[i++] == number)
                {
                    return true;
                }
            }

            // reached the end (or an empty space) and number wasn't found
            return false;
        }


        public virtual ifunc Hash
        {
            get { return (x, n) => x % n; }
            set { hash = value; }
        }
    }
}