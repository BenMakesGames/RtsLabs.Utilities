using System.Collections.Generic;
using System.Numerics;

namespace RtsLabs.Utilities;

public static class CollectionExtensions
{
    /// <summary>
    /// Given a list of numbers, and a threshold, returns a tuple containing the number of items in the list
    /// above the threshold, and the number of items below the threshold. Items which equal the threshold are not
    /// counted.
    ///
    /// interview note: derive the number equal to the threshold yourself, I guess :P
    ///
    /// ALSO: I haven't had an opportunity to really use C#'s new INumber type yet! I've been thinking about doing an
    /// IRandom&lt;T&gt; interface which uses it, because I love the idea of implementing intentionally-bad RNGs (for
    /// speed-runner friendly games), but haven't gotten around to it yet :P
    ///
    /// ALSO-also: I chose to take an ICollection&lt;T&gt; instead of IEnumerable&lt;T&gt;, because operating on a
    /// potentially-infinite stream feels dangerous. if the caller isn't comfortable enumerating the entire collection,
    /// neither am I >_>
    /// </summary>
    /// <param name="input"></param>
    /// <param name="threshold"></param>
    /// <typeparam name="T">Any type which implements INumber&lt;T&gt; (int, float, etc)</typeparam>
    /// <returns></returns>
    public static (int Above, int Below) CountAboveAndBelow<T>(this ICollection<T> input, T threshold)
        where T : INumber<T>
    {
        var above = 0;
        var below = 0;
        
        foreach (var item in input)
        {
            if (item.CompareTo(threshold) > 0)
                above++;
            else if (item.CompareTo(threshold) < 0)
                below++;
        }
        
        return (above, below);
    }
}