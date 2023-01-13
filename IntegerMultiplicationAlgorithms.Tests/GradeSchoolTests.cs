////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName    : integer_multiplication.cs
//Author      : Travis Mann
//Date        : 01/03/2023
//Description : xUnit unit tests for 
////////////////////////////////////////////////////////////////////////////////////////////////////////


// --- imports ---
using System.Numerics;
using Xunit;


// --- classes ---
namespace IntegerMultiplicationAlgorithms.Tests
{
    public class GradeSchoolTests
    {
        [Fact]  // sets up method to run in the testrunner
        public void TestRun()
        {
            // Step 1: Arrange
            BigInteger integer1 = BigInteger.Parse("1234");
            BigInteger integer2 = BigInteger.Parse("5678");
            BigInteger expected = BigInteger.Parse($"{integer1*integer2}");

            // Step 2: Act
            BigInteger actual = GradeSchool.Run(integer1, integer2);

            // Step 3: Assert
            Assert.Equal(expected, actual); 
        }

        [Fact]
        public void TestGetPartialProduct()
        {
            // Step 1: Arrange
            string expected = "11106";

            // Step 2: Act
            char digit = '9';
            string stringInteger = "1234";
            string actual = GradeSchool.GetPartialProduct(digit, stringInteger);

            // Step 3: Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetSingleDigitProduct()
        {
            // Step 1: Arrange
            string[] expected = { "1", "2" };

            // Step 2: Act
            string[] actual = GradeSchool.GetSingleDigitProduct('2', '9', "3");

            // Step 3: Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAddPartialProducts()
        {
            // Step 1: Arrange
            string stringInteger1 = "1234";
            string stringInteger2 = "56780";
            string expected = $"{int.Parse(stringInteger1) + int.Parse(stringInteger2)}";

            // Step 2: Act
            string actual = GradeSchool.AddPartialProducts(new List<string>(new string[] {stringInteger1, stringInteger2}));

            // Step 3: Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSplitDigits()
        {
            // Step 1: Arrange
            string[] expected = {"4", "123"};

            // Step 2: Act
            string[] actual = GradeSchool.SplitDigits("1234");

            // Step 3: Assert
            Assert.Equal(expected, actual);
        }
    }
}
