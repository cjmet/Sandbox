using Sandbox;
using static Sandbox.Overloads;


var _overloads = new Overloads();  // "Overloads() constructor"
_overloads = new Overloads("I'm a String");
_overloads = new Overloads("I'm a String Too", 42);

Console.WriteLine("\n");

HelloPlanet();
HelloPlanet("Paul");
HelloPlanet("Ringo", "our House");

Console.WriteLine("\n");

HelloWorld();                   // "Hello World"
HelloWorld("John");             // "Hello John, ..."
HelloWorld("John", "Earth");    // "Hello John, Welcome to Earth!"
HelloWorld(planet: "Alpha Centauri");
HelloWorld(human: "Jane");
HelloWorld(planet: "Pepper", human: "Jack");



// Example Loops and Best Practice of writing complete syntactically
// correct code blocks first, then filling in the logic later.
Loops.LoopsAndLoops();


