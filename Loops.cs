using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public static class Loops
    {

        // Always write your blocks of code as complete statements
        // That way you can easily add more code to the block later
        // without having to worry about conflating syntax errors
        // and creating more complex debugging issues.
        public static void LoopsAndLoops()
        {

            if (true)
            {
                /* No Op */
            }
            else
            {
                /* No Op */
            }


            for (int i = 0; i < 10; i++)
            {
                /* No Op */
            }


            while (true)
            {
                /* No Op */
                break;
            }


            do
            {
                /* No Op */
            } while (false);


            // this one is a bit more complicated
            var iList = new List<int> { 1, 2, 3 };
            foreach (var fValue in iList)
            {
                /* No Op */
            }


            var sValue = 0;
            switch (sValue)
            {
                case 0:
                    /* No Op */
                    break;
                case 1:
                    /* No Op */
                    break;
                default:
                    /* No Op */
                    break;
            }


            var tValue = 0;
            switch (tValue)
            {
                case 0:
                    {
                        /* No Op */
                        break;
                    }
                case 1:
                    {
                        /* No Op */
                        break;
                    }
                default:
                    {
                        /* No Op */
                    }
                    break;
            }
        }

    }
}
