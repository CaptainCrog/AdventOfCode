namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day18
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day18/Day18Test1.txt")]
        public void Part1_CalculatesMinimumNumberOfSteps_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day18("Day18Test1.txt", 12);
            instance.FirstResult.Should().Be(22);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day18/Day18Test1.txt")]
        public void Part2_ProducesFirstCoordinateWhichRendersTheEndUnreachable_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day18("Day18Test1.txt", 12);
            instance.SecondResult.Should().Be((1,6));
        }
    }
}