using System.Collections.Generic;
using Xunit;
using static AssertNet.Assertions;

namespace DistanceEverything.Tests
{
    /// <summary>
    /// Test class for the <see cref="Levenshtein"/> class.
    /// </summary>
    public static class LevenshteinTests
    {
        /// <summary>
        /// Checks that string inputs respond with the correct distance.
        /// </summary>
        /// <param name="a">The first string.</param>
        /// <param name="b">The second string.</param>
        /// <param name="expectedValue">The expected value.</param>
        [Theory]
        [InlineData("a", "a", 0)]
        [InlineData("ab", "abc", 1)]
        [InlineData("abc", "abc", 0)]
        [InlineData("abc", "abd", 1)]
        [InlineData("abc", "adc", 1)]
        [InlineData("abc", "dbc", 1)]
        [InlineData("abc", "ac", 1)]
        [InlineData("abc", "abcd", 1)]
        [InlineData("abc", "", 3)]
        [InlineData("", "abc", 3)]
        [InlineData("abc", null, 3)]
        [InlineData(null, "abc", 3)]
        [InlineData(null, null, 0)]
        [InlineData("", "", 0)]
        public static void Strings(string a, string b, int expectedValue)
            => AssertThat(Levenshtein.Distance(a, b)).IsEqualTo(expectedValue);

        /// <summary>
        /// Checks that string inputs respond with the correct distance.
        /// </summary>
        /// <param name="a">The first string.</param>
        /// <param name="b">The second string.</param>
        /// <param name="expectedValue">The expected value.</param>
        [Theory]
        [InlineData("a", "a", 0)]
        [InlineData("ab", "abc", 1)]
        [InlineData("abc", "abc", 0)]
        [InlineData("abc", "abd", 1)]
        [InlineData("abc", "adc", 1)]
        [InlineData("abc", "dbc", 1)]
        [InlineData("abc", "ac", 1)]
        [InlineData("abc", "abcd", 1)]
        [InlineData("abc", "", 3)]
        [InlineData("", "abc", 3)]
        [InlineData("abc", null, 3)]
        [InlineData(null, "abc", 3)]
        [InlineData(null, null, 0)]
        [InlineData("", "", 0)]
        public static void Enumerables(string a, string b, int expectedValue)
            => AssertThat(Levenshtein.Distance((IEnumerable<char>)a, b)).IsEqualTo(expectedValue);
    }
}
