////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName    : RecursiveAlgorithm.cs
//Author      : Travis Mann
//Date        : 01/12/2023
//Description : Integer multiplication using a divide and conquer paradigm algorithm
////////////////////////////////////////////////////////////////////////////////////////////////////////


// --- imports ---
using System.Numerics;


// --- classes ---
namespace IntegerMultiplicationAlgorithms
{
    public class RecursiveAlgorithm
    {
        static public BigInteger Run(BigInteger integer1, BigInteger integer2)
        {
            /// <summary>Recursive integer multiplication algorithm</summary>
            /// <param name="integer1">first integer to multiply</param>
            /// <param name="integer2">second integer to multiply</param>
            /// <returns>product between given integers</returns>
            
            // step 1: check base case (both integers are a single digit)
            if (integer1.ToString().Length == 1 || integer2.ToString().Length == 1)
            {
                return integer1 * integer2;
            }

            // step 2: split integers
            BigInteger[] integer1Halves = SplitInteger(integer1);
            BigInteger[] integer2Halves = SplitInteger(integer2);

            // step 3: compute products recursively
            BigInteger ac = Run(integer1Halves[0], integer2Halves[0]);
            BigInteger ad = Run(integer1Halves[0], integer2Halves[1]);
            BigInteger bc = Run(integer1Halves[1], integer2Halves[0]);
            BigInteger bd = Run(integer1Halves[1], integer2Halves[1]);

            // step 4: combine smaller products
            // x = 10^(n/2)*a + b for an n digit number x
            // y = 10^(n/2)*c + d for an n digit number y
            // Thus, x*y = 10^n(a*c) + 10^(n/2)*(ad+bc)+bd
            int n = integer1.ToString().Length;
            BigInteger product = BigInteger.Pow(10, n) * ac + BigInteger.Pow(10, n/2) * (ad+bc) + bd;
            return product;

        }

        static public BigInteger[] SplitInteger(BigInteger integer)
        {
            /// <summary>Recursive integer multiplication algorithm</summary>
            /// <param name="stringInteger">integer as a string to split</param>
            /// <returns>product between given integers</returns>

            // step 1: convert to string for easy digit access
            string stringInteger = integer.ToString();

            // step 2: split string in half
            int splitIndex = stringInteger.Length / 2;
            string firstHalf = stringInteger.Substring(0, splitIndex);
            string secondHalf = stringInteger.Substring(splitIndex, stringInteger.Length - splitIndex);

            // step 3: package and return 
            return new BigInteger[] { BigInteger.Parse(firstHalf), BigInteger.Parse(secondHalf) };
        }
    }
}
