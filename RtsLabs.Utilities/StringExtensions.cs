using System;

namespace RtsLabs.Utilities;

public static class StringExtensions
{
    /// <summary>
    /// Shift the characters in `input` right by `count` positions. Characters shifted off the end are prepended.
    ///
    /// interview note: if I'm being honest, I wouldn't usually write a docblock like this, but for an algorithm, it
    /// seems legit :P 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="count">A non-negative number.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static string RotateRight(this string input, int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        if (input.Length == 0 || count == 0 || count % input.Length == 0)
            return input;

        // interview note: I didn't performance test doing a modulo twice; feels a bit micro-optimization-y :P
        count %= input.Length;
        
        return input[^count..] + input[..^count];
    }
}