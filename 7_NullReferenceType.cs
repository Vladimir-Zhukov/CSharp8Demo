using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8Demo
{
    // https://docs.microsoft.com/ru-ru/dotnet/csharp/tutorials/nullable-reference-types

    // #nullable enable
    class NullReferenceTypeDemo
    {
        public static void Do()
        {
            var p = new Person("Dmitri", "Nesteruk", null);
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Person(string first, string last, string middle) =>
          (FirstName, LastName, MiddleName) = (first, last, middle);
        public string FullName =>
          $"{FirstName} {MiddleName[0]} {LastName}"; // o_O ?! or !?
    }
}
