////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName    : KaratsubasAlgorithm.cs
//Author      : Travis Mann
//Date        : 01/12/2023
//Description : Integer multiplication using Karatsuba's algorithm
////////////////////////////////////////////////////////////////////////////////////////////////////////


// --- imports ---
using System.Numerics;


// --- classes ---
namespace IntegerMultiplicationAlgorithms
{
    public class KaratsubasAlgorithm
    {
        static public BigInteger Run(BigInteger integer1, BigInteger integer2)
        {
            /// <summary>Karatsuba's multiplication algorithm</summary>
            /// <param name="integer1">first integer to multiply</param>
            /// <param name="integer2">second integer to multiply</param>
            /// <returns>product between given integers</returns>

            // step 1: check base case (both integers are a single digit)
            if (integer1.ToString().Length == 1 || integer2.ToString().Length == 1)
            {
                return integer1 * integer2;
            }

            // step 2: split integers
            BigInteger[] integer1Halves = RecursiveAlgorithm.SplitInteger(integer1);
            BigInteger[] integer2Halves = RecursiveAlgorithm.SplitInteger(integer2);

            // step 3: compute ac
            BigInteger ac = Run(integer1Halves[0], integer2Halves[0]);

            // step 4: compute bd
            BigInteger bd = Run(integer1Halves[1], integer2Halves[1]);

            // step 5: compute (a+b)(c+d)
            BigInteger step5Result = Run((integer1Halves[0] + integer1Halves[1]), (integer2Halves[0] + integer2Halves[1]));

            // step 6: compute step 5 - step 4 - step 3
            BigInteger step6Result = step5Result - bd - ac;

            // step 7: add step 3 padded with n zeros, step 4 & step 6 with n/2 zeros
            int n = integer1.ToString().Length;
            BigInteger acPadded = BigInteger.Parse(ac.ToString() + String.Concat(Enumerable.Repeat("0", n)));
            BigInteger step6ResultPadded = BigInteger.Parse(step6Result.ToString() + String.Concat(Enumerable.Repeat("0", n/2)));
            return acPadded + bd + step6ResultPadded;
        }
    }
}
