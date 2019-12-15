using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharp8Demo
{
    // https://docs.microsoft.com/ru-ru/dotnet/csharp/tutorials/generate-consume-asynchronous-stream
    class AsynchronousStreamsDemo
    {
        public async static void Do()
        {
            await foreach (var number in GenerateSequence())
            {
                Console.WriteLine(number);
            }
        }

        public static async IAsyncEnumerable<int> GenerateSequence()
        {
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(100);
                yield return i;
            }
        }
    }

    
}
