////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName    : integer_multiplication.cs
//Author      : Travis Mann
//Date        : 01/07/2023
//Description : Script for running the merge sort algorithm
////////////////////////////////////////////////////////////////////////////////////////////////////////


// --- imports ---
using System.Numerics;


// --- methods ---
namespace IntegerMultiplicationAlgorithms
{
    internal class grade_school
    {
    static BigInteger GradeSchool(BigInteger integer1, BigInteger integer2)
        {
            /// <summary> Grade school integer multiplication algorithm </summary>
            /// <param name="integer1">first integer to multiply</param>
            /// <param name="integer2">second integer to multiply</param>
            /// <returns> None </returns>

            // declair vars for algorithm iterations
            char digitInteger1;        // current digit from integer 1
            char digitInteger2;        // current digit from integer 2
            int partialProduct;        // partial product between digit1 and digit2
            char carryDigit;           // extra digits to carry to next partial product
            string totalDigitProduct;  // total product for a single digit from integer 2 agaist entire integer 1

            // loop through digits in 2nd number
            for (int digitIndex2 = integer2.ToString().Length - 1; digitIndex2 <= 0; digitIndex2--)
            {
                // get next digit from the 2nd integer
                digitInteger2 = getDigit(digitIndex2, digitIndex2);

                // reset carryDigit
                carryDigit = '0';

                // track total product for a single digit from integer 2 agaist entire integer 1
                totalDigitProduct = $"{'0' * digitIndex2}";

                // loop through digits from the 1st integer
                for (int digitIndex1 = integer2.ToString().Length - 1; digitIndex1 <= 0; digitIndex1--)
                {
                    // get next digit from the 1st integer
                    digitInteger1 = getDigit(digitIndex2, digitIndex2);

                    // get partial product
                    char[] partialProductDigits = getPartialProduct(digitInteger1, digitInteger2, carryDigit);
                    int singlesDigit = partialProductDigits[0];
                    carryDigit = partialProductDigits[1];
                    
                    // add right-most digit to the left of totalDigitProduct
                    totalDigitProduct = singlesDigit + totalDigitProduct;
                }

            }

            return integer1 * integer2;
        }

    static char getDigit(int integer, int index)
        {
            /// <summary> returns digit from integer at given index</summary>
            /// <param name="integer">integer to get digit from</param>
            /// <param name="index">index of digit to return</param>
            /// <returns> None </returns>

            // convert integer to a string
            string stringInteger = integer.ToString();

            // index string at given index
            return stringInteger[index];
        }

    static char[] getPartialProduct(int digit1, int digit2, char carryDigit)
    {
        /// <summary> get the partial product of 2 single digits, 
        ///           add an optional carry digit from a previous 
        ///           partial product and split the product into a 
        ///           main digit and a carry digit </summary>
        /// <param name="digit1">integer to get digit from</param>
        /// <param name="digit2">index of digit to return</param>
        /// <param name="carryDigit"></param>
        /// <returns> 
        /// <param name="singlesDigit"> digit in singles place, 10s place digit 
        ///                             is separated into a carry digit </param>
        /// <param name="carryDigit"> 2nd digit to carry over to 
        ///                           next partial product </param>
        /// </returns>

        // mutiply the 2 integers
        int partialProduct = digit1 * digit2;

        // add current carry digit
        partialProduct += carryDigit;

        // separate potential extra digit if partialProduct > 9
        if (partialProduct.ToString().Length > 1)
        {
            carryDigit = partialProduct.ToString()[0];  // max extra digits = 1, 9*9 = 81
        }
        else
        {
            carryDigit = '0';
        }

        // extract singles digit
        char singlesDigit = partialProduct.ToString()[0];

        // package digits and return
        char[] digits = {singlesDigit, carryDigit};
        return digits;


    }
    
    }
}
