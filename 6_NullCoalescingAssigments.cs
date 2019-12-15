using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8Demo
{
    // https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/operators/null-coalescing-operator
    public class NullCoalescingAssigmentDemo
    {
        public static void Do()
        {
            var examples = new ListDemo();
            //examples.LuckyNumbers ??= new List<int>();
            examples.LuckyNumbers.Add(42);

            // загадка
            List<int> numbers = null;
            int? i = null;

            numbers ??= new List<int>();
            numbers.Add(i ??= 17);
            numbers.Add(i ??= 20);

            Console.WriteLine(string.Join(" ", numbers));
            Console.WriteLine(i);
        }
    }

    public class ListDemo
    {
        public List<int> LuckyNumbers { get; set; }
    }
}
