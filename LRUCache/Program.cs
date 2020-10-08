using System;

namespace LRUCache
{
    class Program
    {
        static void Main(string[] args)
        {

            Cache<int, char> cachhe = new Cache<int, char>(5);

            cachhe.Put(1, 'a');
            cachhe.Put(2, 'b');
            cachhe.Put(3, 'c');
            cachhe.Put(4, 'd');
            cachhe.Put(5, 'e');
            cachhe.Put(6, 'f');

            char a = default;
            bool shouldntExist = cachhe.TryGetValue(1, out a);

            char b = default;
            bool shouldExist = cachhe.TryGetValue(2, out b);

            cachhe.Put(7, 'g');

            char c = default;
            bool shouldntTrue = cachhe.TryGetValue(1, out c);

            char bb = default;
            bool shouldTrue = cachhe.TryGetValue(2, out bb);

        }
    }
}
