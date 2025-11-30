// class Program
// {
//     static void Main()
//     {
//         List<int> numbers = new List<int> { 12, 45, 7, 30, 22 };

//         var maxValue = numbers.Max();

//         Console.WriteLine("Max Value: " + string.Join(", ", maxValue));
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         List<string> numbers = new List<string> { "apple", "banana", "cherry" };

//         var maxValue = numbers.Select(x => x.ToUpper());

//         Console.WriteLine("Upper Case: " + string.Join(", ", maxValue));
//     }
// }


// class Program
// {
//     static void Main()
//     {
//         List<string> numbers = new List<string> { "tree", "dog", "elephant", "cat" };

//         var maxValue = numbers.Where(x => x.Contains('e'));

//         Console.WriteLine("Words Found: " + string.Join(", ", maxValue));
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         List<int> numbers = new List<int> { 1, 2, 2, 3, 4, 4, 5 };

//         var maxValue = numbers.Distinct();

//         Console.WriteLine("Distinct Numbers: " + string.Join(", ", maxValue));
//     }
// }


class Program
{
    static void Main()
    {
        List<string> names = new List<string> { "Steve", "Anna", "Mike", "Bob" };

        names.Sort();

        Console.WriteLine("Sorted Names: " + string.Join(", ", names));
    }
}
