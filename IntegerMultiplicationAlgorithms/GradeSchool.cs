////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName    : GradeSchool.cs
//Author      : Travis Mann
//Date        : 01/03/2023
//Description : Integer multiplication using basic grade school algorithm
////////////////////////////////////////////////////////////////////////////////////////////////////////


// --- imports ---
using System.Numerics;


// --- methods ---
namespace IntegerMultiplicationAlgorithms
{
    public class GradeSchool
    {
        static public BigInteger Run(BigInteger integer1, BigInteger integer2)
        {
            /// <summary>Grade school integer multiplication algorithm</summary>
            /// <param name="integer1">first integer to multiply</param>
            /// <param name="integer2">second integer to multiply</param>
            /// <returns>product of integer1 and integer2</returns>

            // step 1: convert integers to strings to access digits
            string stringInteger1 = integer1.ToString();
            string stringInteger2 = integer2.ToString();

            // step 2: compute partial products for each digit of the 1st integer
            // loop through digits right to left
            List<string> partialProducts = new List<string>();
            for (int digitIndex = stringInteger1.Length - 1; digitIndex >= 0; digitIndex--)
            {
                // step 2.2: extract digit from integer string
                char digit = stringInteger1[digitIndex];

                // step 2.3: compute partial product between digit and opposing integer
                string partialProduct = GetPartialProduct(digit, stringInteger2);

                // step 2.4: multiply by 10^n where n is the digit index from right to left
                // adds n 0s to the right side of the string to achieve this
                int zeroCount = stringInteger1.Length - 1 - digitIndex;
                partialProduct += String.Concat(Enumerable.Repeat("0", zeroCount));

                // step 2.5: add finised partial product to list
                partialProducts.Add(partialProduct);  // add partial product to list
            }

            // step 3: add digits across partial products for final product
            return BigInteger.Parse(AddPartialProducts(partialProducts));
        }

        static public string GetPartialProduct(char digit, string stringInteger)
        {
            /// <summary>Computes product between a single digit and an integer of any length.</summary>
            /// <param name="digit">single digit as a char</param>
            /// <param name="stringInteger">integer of any length as a string</param>
            /// <returns>product between digit and integer</returns>

            // step 0: initialize tens digit and partial product string
            string partialProduct = "";
            string tensDigit = "0";

            // step 1: iterate over all digits in given integer
            for (int digitIndex = stringInteger.Length - 1; digitIndex >= 0; digitIndex--)
            {
                // step 1.1: extract digit from integer
                char stringIntegerDigit = stringInteger[digitIndex];

                // step 1.2: get product digits from multiplying both single digits
                string[] digitsProductDigits = GetSingleDigitProduct(digit, stringIntegerDigit, tensDigit);
                string singlesDigit = digitsProductDigits[0];
                tensDigit = digitsProductDigits[1];

                // step 1.3: add singles digit to the left of the partial product
                partialProduct = singlesDigit + partialProduct;
            }

            // step 2: add final 10s place if its > 0
            if (tensDigit != "0")
            {
                partialProduct = tensDigit + partialProduct;
            }

            // step 3: output finished partialProduct
            return partialProduct;
        }

        static public string[] GetSingleDigitProduct(char digit1, char digit2, string carryDigit)
        {
            /// <summary>Computes product between 2 single digits and separates 
            ///          answer into list of chars for singles and tens places</summary>
            /// <param name="digit1">single digit as a char</param>
            /// <param name="digit2">single digit as a char</param>
            /// <param name="carryDigit">optional 10s digit to carry from last calculation</param>
            /// <returns>product between the 2 digits</returns>

            // step 1: multiply digits
            int digitsProduct = int.Parse(digit1.ToString()) * int.Parse(digit2.ToString());

            // step 2: add carry digit
            digitsProduct += int.Parse(carryDigit.ToString());

            // step 3: separate digits into singles and 10s place
            return SplitDigits(digitsProduct.ToString());
        }

        static public string AddPartialProducts(List<string> partialProducts)
        {
            /// <summary>adds up the corresponding digits in a list of partial products</summary>
            /// <param name="digit1">single digit as a char</param>
            /// <returns>sumString: sum of partial products</returns>

            // step 1: iterate over all possible digits
            string sumString = "";
            string tensDigit = "0";
            for (int digitIndex = 0; digitIndex < partialProducts.Last().Length; digitIndex++)
            {
                // step 1.1: reset digitSum
                int digitSum = 0;

                // step 1.2: add all digits at current digit index
                foreach (string partialProduct in partialProducts)
                {
                    // step 1.2.1: extract digit, handle index exceptions for shorter partial products
                    char digit;
                    try
                    {
                        digit = partialProduct[partialProduct.Length - 1 - digitIndex];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        continue;  // skip adding this digit because it doesnt exist for this partial product
                    }

                    // step 1.2.2: add digit to digit sum
                    digitSum += int.Parse(digit.ToString());
                }

                // step 1.3: carry previous tens digit 
                digitSum += int.Parse(tensDigit.ToString());

                // step 1.4: get current 10s digit for next loop
                string[] digits = SplitDigits(digitSum.ToString());
                tensDigit = digits[1];

                // step 1.5: append singles digit from sum to total sum
                sumString = digits[0] + sumString;
            }

            // output finalized sum string
            return sumString;
        }

        static public string[] SplitDigits(string digits)
        {
            /// <summary>creates a char list of 2 digits 
            ///          from a string with 1 or 2 digits</summary>
            /// <param name="digits">string of 1 or 2 digits</param>
            /// <returns>product: sum of partial products</returns>

            // check if digits > 10 and assign singles and tens digits accordingly
            string singlesDigit;
            string tensDigit;
            if (digits.Length == 1)
            {
                singlesDigit = digits[0].ToString();
                tensDigit = "0";
            }
            else // digits > 10
            {
                singlesDigit = digits.Last().ToString();
                tensDigit = digits.Substring(0, digits.Length - 1);
            }

            // package and output digits
            return new string[] { singlesDigit, tensDigit };
        }
    }
}
