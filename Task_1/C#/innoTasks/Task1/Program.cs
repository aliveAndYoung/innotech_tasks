using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter a number : ");
            long n = 0;
            string? input;
            input = Console.ReadLine();
            if (input != null)
                n = long.Parse(input);
            if (n <= 0)
                n = 0;


            Console.WriteLine("Summing by  For Loop Approach ... ");
            loopApproach(n);
            Console.WriteLine("Summing by Formula Approach ... ");
            formulaApproach(n);
            Console.WriteLine("Printing");
            printAll(n);


        }


        static void printAll(long n)
        {
            StringBuilder sb = new StringBuilder();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (long i = 0; i <= n; i++)
            {
                sb.Append($"{i} , ");
            }
            sw.Stop();
            sb.Remove(sb.Length - 3, 2);
            Console.WriteLine(sb.ToString());
            Console.WriteLine($"completed in {sw.Elapsed.TotalMilliseconds}");
        }

        static void formulaApproach(long a)
        {
            Stopwatch sw = new Stopwatch();
            long sum = 0;
            sw.Start();
            sum = (a * (a + 1)) / 2;
            sw.Stop();
            Console.WriteLine($"Sum = {sum} \n Time Elapsed : {sw.Elapsed.TotalMilliseconds}");


        }
        static void loopApproach(long a )
        {
            long sum = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (long i = 1; i <= a; i++)
                sum += i;
            
            sw.Stop();
            Console.WriteLine($"Sum = {sum} \n Time Elapsed : {sw.Elapsed.TotalMilliseconds}");
        }
    
    
    }
}

// O(n) for the for loop and O(1) for appending in the stringBuilder


// Also the stringBuilder may need O(n) time to resize and handle more characters
// but it is amortized, so we consider it O(1) for each append

// It's an array of characters that is used to build strings efficiently
// It is mutable, meaning you can change its content without creating a new object

// in contrast of normal strings which are immutable


