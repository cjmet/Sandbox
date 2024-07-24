using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Overloads
    {

        public Overloads () {  // this is a constructor
            Console.WriteLine("Overloads() constructor");
        }
        public Overloads (string s) {  // this is a constructor
            Console.WriteLine($"Overloads(string {s}) constructor");
        }
        public Overloads (string s, int i) {  // this is a constructor
            Console.WriteLine($"Overloads(string {s}, int {i}) constructor");
        }

        public static void HelloPlanet() => HelloPlanet("", "");
        public static void HelloPlanet(string human) => HelloPlanet(human, "");
        public static void HelloPlanet(string human, string planet)
        {
            HelloWorld(human, planet);  // no need to duplicate code in here
        }
        // This could have also been written shorthand as: 
        // public static void HelloPlanet(string human, string planet) => HelloWorld(human, planet);


        // this is the C#12 / .NET 8 optional parameter syntax
        public static void HelloWorld(string human = "", string planet = "")
        {
            if (planet == "" && human == "")
            {
                Console.WriteLine("Hello World");
            }
            else if (planet == "" && human != "")
            {
                Console.WriteLine("Hello " + human + ", Welcome to our World!");
            }
            else if (planet != "" && human == "")
            {
                Console.WriteLine("Hello " + planet);
            }
            else if (planet != "" && human != "")
            {
                Console.WriteLine("Hello " + human + ", Welcome to " + planet + "!");
            }
        }
    }
}
