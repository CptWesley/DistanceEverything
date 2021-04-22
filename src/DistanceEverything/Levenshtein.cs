using System.Collections.Generic;
using System.Linq;

namespace DistanceEverything
{
    /// <summary>
    /// Object used for computing the Levenshtein distance between.
    /// Implementation closely based on Fastenshtein:
    /// https://github.com/DanHarltey/Fastenshtein/blob/c21c674fb66400eb805ccfd7ff23b823253ac0d2/src/Fastenshtein/StaticLevenshtein.cs.
    /// </summary>
    public class Levenshtein
    {
        /// <summary>
        /// Computes the Levenshtein distance between two arbitrary sequences.
        /// </summary>
        /// <typeparam name="T">The type of objects contained in the sequences.</typeparam>
        /// <param name="sequence1">The first sequence.</param>
        /// <param name="sequence2">The second sequence.</param>
        /// <returns>The Levenshtein distance.</returns>
        public static int Distance<T>(IEnumerable<T> sequence1, IEnumerable<T> sequence2)
        {
            if (sequence1 is null && sequence2 is null)
            {
                return 0;
            }

            if (sequence1 is null)
            {
                return sequence2.Count();
            }

            if (sequence2 is null)
            {
                return sequence1.Count();
            }

            T[] s = sequence1.ToArray();
            T[] t = sequence2.ToArray();

            if (s is null && t is null)
            {
                return 0;
            }

            if (s is null)
            {
                return t.Length;
            }

            if (t is null)
            {
                return s.Length;
            }

            if (s.Length < t.Length)
            {
                T[] swap = t;
                t = s;
                s = swap;
            }

            int prefix = 0;
            for (int i = 0; i < t.Length; ++i)
            {
                if (!t[i]!.Equals(s[i]))
                {
                    break;
                }

                ++prefix;
            }

            if (prefix == s.Length)
            {
                return 0;
            }

            int suffix = 0;
            for (int i = 0; i < t.Length; ++i)
            {
                if (!t[t.Length - 1 - i]!.Equals(s[s.Length - 1 - i]))
                {
                    break;
                }

                ++suffix;
            }

            if (t.Length == 0)
            {
                return s.Length;
            }

            int padding = prefix + suffix;
            int tLength = t.Length - padding;
            int sLength = s.Length - padding;
            if (tLength == 0)
            {
                return s.Length - padding;
            }

            int[] costs = new int[tLength];

            for (int i = 0; i < costs.Length;)
            {
                costs[i] = ++i;
            }

            for (int i = 0; i < sLength; ++i)
            {
                int cost = i;
                int previousCost = i;
                T value = s[prefix + i];

                for (int j = 0; j < tLength; ++j)
                {
                    int currentCost = cost;
                    cost = costs[j];

                    if (!value!.Equals(t[prefix + j]))
                    {
                        if (previousCost < currentCost)
                        {
                            currentCost = previousCost;
                        }

                        if (cost < currentCost)
                        {
                            currentCost = cost;
                        }

                        ++currentCost;
                    }

                    costs[j] = currentCost;
                    previousCost = currentCost;
                }
            }

            return costs[tLength - 1];
        }

        /// <summary>
        /// Computes the Levenshtein distance between two strings.
        /// </summary>
        /// <param name="s">The first string.</param>
        /// <param name="t">The second string.</param>
        /// <returns>The Levenshtein distance.</returns>
        public static int Distance(string s, string t)
        {
            if (s is null && t is null)
            {
                return 0;
            }

            if (s is null)
            {
                return t.Length;
            }

            if (t is null)
            {
                return s.Length;
            }

            if (s.Length < t.Length)
            {
                string swap = t;
                t = s;
                s = swap;
            }

            int prefix = 0;
            for (int i = 0; i < t.Length; ++i)
            {
                if (t[i] != s[i])
                {
                    break;
                }

                ++prefix;
            }

            if (prefix == s.Length)
            {
                return 0;
            }

            int suffix = 0;
            for (int i = 0; i < t.Length; ++i)
            {
                if (t[t.Length - 1 - i] != s[s.Length - 1 - i])
                {
                    break;
                }

                ++suffix;
            }

            if (t.Length == 0)
            {
                return s.Length;
            }

            int padding = prefix + suffix;
            int tLength = t.Length - padding;
            int sLength = s.Length - padding;
            if (tLength == 0)
            {
                return s.Length - padding;
            }

            int[] costs = new int[tLength];

            for (int i = 0; i < costs.Length;)
            {
                costs[i] = ++i;
            }

            for (int i = 0; i < sLength; ++i)
            {
                int cost = i;
                int previousCost = i;
                char value = s[prefix + i];

                for (int j = 0; j < tLength; ++j)
                {
                    int currentCost = cost;
                    cost = costs[j];

                    if (value != t[prefix + j])
                    {
                        if (previousCost < currentCost)
                        {
                            currentCost = previousCost;
                        }

                        if (cost < currentCost)
                        {
                            currentCost = cost;
                        }

                        ++currentCost;
                    }

                    costs[j] = currentCost;
                    previousCost = currentCost;
                }
            }

            return costs[tLength - 1];
        }
    }
}
