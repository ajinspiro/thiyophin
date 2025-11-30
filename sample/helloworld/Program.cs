// // See https://aka.ms/new-console-template for more information
// List<int> scores = [1, 43, 23, 4, 212, 43, 24];


// using LINQ query expression syntax
// IEnumerable<int> ScoreQuery = from score in scores
//                               where score > 22
//                               orderby score descending
//                               select score;


// foreach (var score in ScoreQuery)
// {
//     Console.Write($"{score} ");
// }

// Using LINQ Method Syntax (method chaining)
// List<int> scores = [1, 43, 23, 4, 212, 43, 24];
// var selectedScores = scores.Where(s => s > 22).OrderBy(s => s);

// foreach (var score in selectedScores)
// {
//     Console.WriteLine(score);
// }

//------------------------------------------------------------------------------
// oop old coding style

// var p1 = new Person("Theo", "Johnson", new DateOnly(1999, 03, 22));
// public class Person
// {
//     public Person(string first, string last, DateOnly bd)
//     {
//         firstName = first;
//         lastName = last;
//         birthDay = bd;
//     }
//     public string firstName;
//     private string lastName;
//     private DateOnly birthDay;
// }

// oop new coding style, using get and set property and primary constructor

var p1 = new Person("Theo", "Johnson", new DateOnly(1999, 03, 22));
var p2 = new Person("Thipee", "Johnson", new DateOnly(2004, 04, 11));
p1.Pets.Add(new Dog("Tony"));
p1.Pets.Add(new Dog("Manu"));
p2.Pets.Add(new Cat("Mellow"));
List<Person> people = [p1, p2];
Console.WriteLine(people.Count);
foreach (var person in people)
{
    Console.WriteLine(person);
    foreach (var pet in person.Pets)
    {
        Console.WriteLine($"  {pet}");
    }
}


// IEnumerable<Person> peopleHavingDogs = from p in people
//                                        where p.Pets.Any(pet => pet is Dog)
//                                        select p;

var peopleHavingDogs = people
    .Where(p => p.Pets.Any(pet => pet is Dog));

Console.WriteLine($"people having atleast one dog : ");
foreach (var p in peopleHavingDogs)
{
    Console.WriteLine($"  {p}");
}
public class Person(string firstname, string lastname, DateOnly birthday)
{
    public string First { get; } = firstname;
    public string Last { get; } = lastname;
    public DateOnly Birthday { get; } = birthday;
    public List<Pet> Pets { get; } = new();
    public override string ToString()
    {
        return $"{First} {Last}";
    }
}

// The old style uses manual fields + manual constructor.
// The new style uses primary constructor + auto-properties.
// The new style is shorter, more readable, safer, and more idiomatic for modern C#.
// Both versions create objects the same way:

public abstract class Pet(string firstname)
{
    public string First { get; } = firstname;
    public abstract string MakeNoise();
    public override string ToString()
    {
        return $"{First} and I am a {GetType().Name} and I {MakeNoise()}";
    }
}

public class Dog(string firstname) : Pet(firstname)
{
    public override string MakeNoise() => "Bark";
}

public class Cat(string firstname) : Pet(firstname)
{
    public override string MakeNoise() => "Meow";
}