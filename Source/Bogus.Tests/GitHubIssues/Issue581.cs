﻿using FluentAssertions;

namespace Bogus.Tests.GitHubIssues
{
    public class Issue581 : SeededTest
    {
       [Fact]
       public void overflow_test()
       {
          var randomizer = new Randomizer(1337);
          ulong max = ulong.MaxValue;
          ulong min = max - 10;

          ulong result = randomizer.ULong(min, max);

          result.Should().BeInRange(min, max);
       }
   }
}
