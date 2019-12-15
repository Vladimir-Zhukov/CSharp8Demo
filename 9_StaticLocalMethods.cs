using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8Demo
{
    class StaticLocalMethodsDemo
    {
        int M()
        {
            int y = 5;
            int x = 7;
            return Add(x, y);

            static int Add(int left, int right) => left + right;
        }
    }
}
