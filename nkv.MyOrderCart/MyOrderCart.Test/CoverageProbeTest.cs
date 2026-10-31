using MyOrderCart.Services;
using Xunit;

namespace MyOrderCart.Test
{
    public class CoverageProbeTest
    {
        [Fact]
        public void GradesHighScoresAsA()
        {
            Assert.Equal("A", CoverageProbe.Grade(95));
        }

        [Fact]
        public void TotalsPositiveValues()
        {
            Assert.Equal(5, CoverageProbe.Total(new[] { 2, 3, -1 }));
        }
    }
}
