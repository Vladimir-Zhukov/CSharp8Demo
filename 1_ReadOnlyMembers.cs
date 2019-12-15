using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8Demo
{
    // https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/readonly
    // defensive copy
    public struct Rectangle
    {
        public double Length { get; set; }
        public double Heigth { get; set; }

        private double _height;
        public /*readonly*/ double Heigth2
        {
            /*readonly*/ get { return _height; }
            set { _height = value; }
        }

        public readonly double Area()
        {
            //Heigth += 1;
            return Length * Heigth;
        }
    }
}
