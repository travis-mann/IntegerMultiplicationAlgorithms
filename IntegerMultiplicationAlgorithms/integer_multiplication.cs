////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName    : integer_multiplication.cs
//Author      : Travis Mann
//Date        : 01/03/2023
//Description : Script for running the merge sort algorithm
////////////////////////////////////////////////////////////////////////////////////////////////////////


// --- imports ---
using System.Numerics;


// --- methods ---
BigInteger GradeSchool(BigInteger integer1, BigInteger integer2)
{
    /// <summary> Grade school integer multiplication algorithm </summary>
    /// <param name="integer1">first integer to multiply</param>
    /// <param name="integer2">second integer to multiply</param>
    /// <returns> None </returns>

    // convert integers to strings to access digits
    string stringInteger1 = integer1.ToString();
    string stringInteger2 = integer2.ToString();

    // declair vars for algorithm iterations
    char digitInteger1;        // current digit from integer 1
    char digitInteger2;        // current digit from integer 2
    int partialProduct;        // partial product between digit1 and digit2
    char carryDigit;           // extra digits to carry to next partial product
    string totalDigitProduct;  // total product for a single digit from integer 2 agaist entire integer 1

    // loop through digits in 2nd number
    for (int digitIndex2 = stringInteger2.Length - 1; digitIndex2 <= 0; digitIndex2--)
    {
        // get next digit from the 2nd integer
        digitInteger2 = stringInteger2[digitIndex2];

        // reset carryDigit
        carryDigit = '0';

        // track total product for a single digit from integer 2 agaist entire integer 1
        totalDigitProduct = $"{'0'*digitIndex2}";

        // loop through digits from the 1st integer
        for (int digitIndex1 = stringInteger2.Length - 1; digitIndex1 <= 0; digitIndex1--)
        {
            // get next digit from the 1st integer
            digitInteger1 = stringInteger1[digitIndex1];

            // mutiply the 2 integers
            partialProduct = digitInteger2 * digitInteger1;

            // add current carry digit
            partialProduct += carryDigit;

            // separate potential extra digit if partialProduct > 9
            if (partialProduct.ToString().Length > 1)
            {
                carryDigit = partialProduct.ToString()[0];  // max extra digits = 1, 9*9 = 81
            }

            // add right-most digit to the left of totalDigitProduct
            totalDigitProduct = partialProduct.ToString()[-1] + totalDigitProduct;
        } 

    }

    return integer1 * integer2;
}

BigInteger RecursiveMultiplication(BigInteger integer1, BigInteger integer2)
{
    /// <summary> Divide and conquer algorithm for integer multiplication </summary>
    /// <param name="integer1">first integer to multiply</param>
    /// <param name="integer2">second integer to multiply</param>
    /// <returns> None </returns>

    return integer1 * integer2;
}

BigInteger KaratsubasAlgorithm(BigInteger integer1, BigInteger integer2)
{
    /// <summary> Karatsuba's integer multiplication algorithm </summary>
    /// <param name="integer1">first integer to multiply</param>
    /// <param name="integer2">second integer to multiply</param>
    /// <returns> None </returns>

    return integer1 * integer2;
}


// --- main ---
BigInteger integer1 = BigInteger.Parse("3141592653589793238462643383279502884197169399375105820974944592");
BigInteger integer2 = BigInteger.Parse("2718281828459045235360287471352662497757247093699959574966967627");
BigInteger answer = integer1 * integer2;

Console.WriteLine($"Answer: {answer}");
Console.WriteLine($"Grade School: {GradeSchool(integer1, integer2) == answer}");
Console.WriteLine($"Recursive Multiplication: {RecursiveMultiplication(integer1, integer2) == answer}");
Console.WriteLine($"Karatsubas Algorithm: {KaratsubasAlgorithm(integer1, integer2) == answer}");
