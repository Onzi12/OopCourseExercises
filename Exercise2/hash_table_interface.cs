namespace Exercise2
{

    internal delegate int ifunc(int x, int n);


    internal interface hash_table_interface
    {
        void insert(int number);
        bool is_member(int number);

        /// <summary>
        /// The Hash function
        /// </summary>
        ifunc Hash { get; }
    }

}