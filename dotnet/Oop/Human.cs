
using System.Reflection.Metadata.Ecma335;

namespace Demo;

public interface IAnimal
{
    public int Weight { get; set; }
    public float Height { get; set; }

    public void Walk();
}

public class Human : IAnimal
{
    public string? Name { get; set; }
    public DateTimeOffset BirthDay { get; set; }
    public int Weight { get; set; }
    public float Height { get; set; }

    public void Walk()
    {
        System.Console.WriteLine("Humans walk using 2 legs only");
    }

    public override string ToString()
    {
        return $"Name: {Name}, Weight: {Weight}, Height:{Height}, Birthday:{BirthDay}";
    }
}
