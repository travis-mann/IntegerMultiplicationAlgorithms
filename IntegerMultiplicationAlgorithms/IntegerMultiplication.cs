////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName    : IntegerMultiplication.cs
//Author      : Travis Mann
//Date        : 01/12/2023
//Description : Script for running various integer multiplication algorithms
////////////////////////////////////////////////////////////////////////////////////////////////////////


// --- imports ---
using System.Numerics;


// --- classes ---
namespace IntegerMultiplicationAlgorithms
{
    internal class IntegerMultiplication
    {
        static void Main()
        {
            // --- main ---
            // initialize parameters
            BigInteger integer1 = BigInteger.Parse("3141592653589793238462643383279502884197169399375105820974944592");
            BigInteger integer2 = BigInteger.Parse("2718281828459045235360287471352662497757247093699959574966967627");

            // run algorithms
            string[] algorithmNames = { "GradeSchool", "RecursiveAlgorithm", "KaratsubasAlgorithm" };
            List<Func<BigInteger>> methods = new List<Func<BigInteger>>();
            methods.Add(() => GradeSchool.Run(integer1, integer2));
            methods.Add(() => RecursiveAlgorithm.Run(integer1, integer2));
            methods.Add(() => KaratsubasAlgorithm.Run(integer1, integer2));

            int algorithmNameIndex = 0;
            foreach (var method in methods)
            {
                // get start time
                TimeSpan startTime = DateTime.Now.TimeOfDay;

                // run algorithm
                BigInteger answer = method();

                // show answer
                string algorithmName = algorithmNames[algorithmNameIndex];
                algorithmNameIndex++;
                Console.WriteLine($"{algorithmName}: {answer}");
                
                // show total run time
                TimeSpan endTime = DateTime.Now.TimeOfDay;
                Console.WriteLine($"{algorithmName} Run Time {endTime - startTime}");
            }
        }
    }
}