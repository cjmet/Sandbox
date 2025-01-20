using Instances;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui;
using Newtonsoft.Json;
using static AngelHornetLibrary.CLI.CliSystem;

class Program
{
    static void Main(string[] args)
    {
        string fileName = FindFileInVisualStudio("LICENSE.txt");
        Console.WriteLine($"Filename: {fileName}");

        /* 
        Casting with Inheritance:

            "Casting Forward" (Upcasting):
                * Casting an instance of a derived class to its base class.
                * Always safe and implicit.
                * Example:
                    class Animal { }
                    class Dog : Animal { }

                    Dog myDog = new Dog();
                    Animal myAnimal = myDog; // Upcasting (implicit)

            "Casting Backward" (Downcasting):
                * Casting an instance of a base class to its derived class.
                * Requires an explicit cast and may throw an InvalidCastException if the actual object is not an instance of the derived class.
        */

        var parent = new Parent();
        parent.name = "I'm a Parent";
        var child = new Child();
        child.name = "I'm a Child";
  
        var castBackward = child as Parent;
        Console.WriteLine($"child as Parent:{castBackward.name}");
        
        var castForward = parent as Child;
        castForward ??= new Child { name = "isNull" };
        Console.WriteLine($"parent as Child: {castForward.name}");

    }
}

public class Parent
{
    public int id { get; set; }
    public string name { get; set; }
    public string parent { get; set; }
}

public class Child : Parent
{
    public string child { get; set; }
}
