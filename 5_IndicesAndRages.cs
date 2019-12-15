using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8Demo
{
    // https://docs.microsoft.com/ru-ru/dotnet/csharp/tutorials/ranges-indexes#type-support-for-indices-and-ranges
    class IndicesAndRagesDemo
    {
        public static void Do()
        {
            var places = new string[] { "first", "second", "third", "fourth", "fifth" };
            
            var last = places[^1];
            Console.WriteLine(last);
            
            var beforeLast = places[^2];
            Console.WriteLine(beforeLast);

            foreach (var item in places[2..4]) // [1..^1], [..^1]
            {
                Console.WriteLine(item);
            }
        }
    }
}
