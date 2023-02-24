using System;
using FluentAssertions;
using Xunit;

namespace RtsLabs.Utilities.Tests;

public sealed class StringExtensionTests
{
    // interview note: bool flags for methods always throw a red flag for me, but it also feels weird to only test the
    // negative case in situations like this?? nets out to "I don't have strong opinions in this case" :P curious to
    // hear your opinion.
    [Theory]
    [InlineData(-1, true)]
    [InlineData(int.MinValue, true)]

    [InlineData(0, false)]
    [InlineData(1, false)]
    [InlineData(int.MaxValue, false)]
    public void RotateRight_ThrowsOnNegativeCount(int count, bool shouldThrow)
    {
        const string anyString = "any string";

        if(shouldThrow)
        {
            anyString.Invoking(x => x.RotateRight(count))
                .Should().Throw<ArgumentOutOfRangeException>();
        }
        else
        {
            anyString.Invoking(x => x.RotateRight(count))
                .Should().NotThrow<ArgumentOutOfRangeException>();
        }
    }
    
    [Theory]
    [InlineData("", 0, "")]
    [InlineData("", 1, "")]
    [InlineData("", int.MaxValue, "")]
    [InlineData("any of length 16", 0, "any of length 16")]
    [InlineData("any of length 16", 1, "6any of length 1")]
    [InlineData("any of length 16", 10, " length 16any of")]
    [InlineData("any of length 16", 16, "any of length 16")]
    [InlineData("any of length 16", 17, "6any of length 1")]
    public void RotateRight_ShiftsCharactersRight(string input, int count, string expected)
    {
        input.RotateRight(count).Should().Be(expected);
    }
}