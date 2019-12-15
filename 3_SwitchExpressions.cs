using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8Demo
{
    // https://docs.microsoft.com/ru-ru/dotnet/csharp/tutorials/pattern-matching
    public class SwitchExpressions
    {
        class Person
        {
            public PhoneNumber PhoneNumber;
            public string Name;
        }

        class PhoneNumber
        {
            public int Code, Number;
        }

        class ExtendedPhoneNumber : PhoneNumber
        {
            public string Office { get; set; }
        }

        public void Do()
        {
            var phoneNumber = new PhoneNumber();
            var origin = phoneNumber switch
            {
                { Number: 112 } => "Emergency",
                { Code: 44 } => "UK",
                { } => "Indeterminate", //любой аргумент который не null
                _ => "Missing"
            };

            /* рекурсивные паттерны */
            var person = new Person();            
            var personsOrigin = person switch
            {
                { Name: "Dmitri" } => "Russia",
                { PhoneNumber: { Code: 46 } } => "Sweden", // можно углубиться в объект
                { Name: var name } => $"No idea where {name} lives" // можно задекларировать переменную и в нее записать найденное значение чтобы им с последствии пользоваться
            };

            // комплесная валидация разных аспектов одного сложного объекта
            var error = person switch
            {
                null => "Object missing",
                { PhoneNumber: null } => "Phone number missing entirely",
                { PhoneNumber: { Number: 0 } } => "Actual number missing",
                { PhoneNumber: { Code: var code } } when code < 0 => "WTF?",
                { } => null // no error
            };
            if (error != null)
                throw new ArgumentException(error);

            // интеграция с проверками на типы
            var numbers = new List<PhoneNumber>()
            {
                new PhoneNumber(),
                new ExtendedPhoneNumber()
            };

            var list = GetMainOfficeNumbers(numbers);

            // Деконструкция
            GetQuadrant(new Point(1, 2));
        }

        IEnumerable<int> GetMainOfficeNumbers(IEnumerable<PhoneNumber> numbers)
        {
            foreach (var pn in numbers)
            {
                if (pn is ExtendedPhoneNumber { Office: "main" })
                    yield return pn.Number;
            }
        }

        public class Point
        {
            public int X { get; }
            public int Y { get; }

            public Point(int x, int y) => (X, Y) = (x, y);

            public void Deconstruct(out int x, out int y) =>
                (x, y) = (X, Y);
        }

        /* Квадрант. Четверть круга */
        public enum Quadrant
        {
            Unknown,
            Origin,
            One,
            Two,
            Three,
            Four,
            OnBorder
        }

        /// <summary>
        /// Определение в каком квадранте лежит точка
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        static Quadrant GetQuadrant(Point point) => point switch
        {
            (0, 0) => Quadrant.Origin,
            var (x, y) when x > 0 && y > 0 => Quadrant.One,
            var (x, y) when x < 0 && y > 0 => Quadrant.Two,
            var (x, y) when x < 0 && y < 0 => Quadrant.Three,
            var (x, y) when x > 0 && y < 0 => Quadrant.Four,
            var (_, _) => Quadrant.OnBorder,
            _ => Quadrant.Unknown
        };
    }
}
