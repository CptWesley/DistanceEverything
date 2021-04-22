using System.Collections.Generic;
using System.Linq;

namespace DistanceEverything
{
    /// <summary>
    /// Used for computing n-gram distances.
    /// </summary>
    public static class Ngram
    {
        /// <summary>
        /// Computes the n-gram distance between two strings.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <param name="s">The first string.</param>
        /// <param name="t">The second string.</param>
        /// <returns>The n-gram distance between the given strings.</returns>
        public static int Distance(int n, string s, string t)
        {
            HashSet<string> sl = new HashSet<string>();
            HashSet<string> tl = new HashSet<string>();

            for (int i = 0; i < s.Length - n + 1; i++)
            {
                sl.Add(s.Substring(i, n));
            }

            for (int i = 0; i < t.Length - n + 1; i++)
            {
                tl.Add(t.Substring(i, n));
            }

            int intersection = sl.Intersect(tl).Count();

            return sl.Count + tl.Count - (2 * intersection);
        }
    }
}
