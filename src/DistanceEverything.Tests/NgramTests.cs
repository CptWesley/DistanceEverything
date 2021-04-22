using Xunit;
using static AssertNet.Assertions;

namespace DistanceEverything.Tests
{
    /// <summary>
    /// Test class for the <see cref="Ngram"/> class.
    /// </summary>
    public static class NgramTests
    {
        /// <summary>
        /// Checks that string inputs respond with the correct distance.
        /// </summary>
        /// <param name="a">The first string.</param>
        /// <param name="b">The second string.</param>
        /// <param name="expectedValue">The expected value.</param>
        [Theory]
        [InlineData("abcd", "abcd", 0)]
        [InlineData("abcde", "abcd", 1)]
        [InlineData("abcdef", "abcd", 2)]
        [InlineData("abcd", "abcdef", 2)]
        [InlineData("zzabcd", "abcdef", 4)]
        public static void Strings(string a, string b, int expectedValue)
            => AssertThat(Ngram.Distance(2, a, b)).IsEqualTo(expectedValue);
    }
}
