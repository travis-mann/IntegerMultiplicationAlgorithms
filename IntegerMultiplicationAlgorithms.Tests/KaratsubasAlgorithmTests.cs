////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName    : KaratsubasAlgorithmTests.cs
//Author      : Travis Mann
//Date        : 01/13/2023
//Description : xUnit unit tests for KaratsubasAlgorithm.cs
////////////////////////////////////////////////////////////////////////////////////////////////////////


// --- imports ---
using System.Numerics;
using Xunit;


// --- classes ---
namespace IntegerMultiplicationAlgorithms.Tests
{
    public class KaratsubasAlgorithmTests
    {
        [Fact]  // sets up method to run in the testrunner
        public void TestRun()
        {
            // Step 1: Arrange
            BigInteger integer1 = BigInteger.Parse("1234");
            BigInteger integer2 = BigInteger.Parse("5678");
            BigInteger expected = BigInteger.Parse($"{integer1*integer2}");

            // Step 2: Act
            BigInteger actual = KaratsubasAlgorithm.Run(integer1, integer2);

            // Step 3: Assert
            Assert.Equal(expected, actual); 
        }
    }
}
