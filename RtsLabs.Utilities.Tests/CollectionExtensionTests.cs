using FluentAssertions;
using Xunit;

namespace RtsLabs.Utilities.Tests;

public sealed class CollectionExtensionTests
{
    private const int AnyThreshold = 999;
    
    [Theory]
    [InlineData(new[] { 7, 3, 4, 4 }, 1,   4, 0)] // all above
    [InlineData(new[] { 7, 3, 4, 4 }, 9,   0, 4)] // all below
    [InlineData(new[] { 7, 3, 4, 4 }, 5,   1, 3)] // some of both
    [InlineData(new[] { 7, 3, 4, 4 }, 4,   1, 1)] // a threshold which is in the set
    [InlineData(new int[] { }, AnyThreshold, 0, 0)] // an empty set
    public void CountAboveAndBelow_ReturnsCorrectCounts(int[] input, int threshold, int expectedAbove, int expectedBelow)
    {
        input.CountAboveAndBelow(threshold).Should().Be((expectedAbove, expectedBelow));
    }
}