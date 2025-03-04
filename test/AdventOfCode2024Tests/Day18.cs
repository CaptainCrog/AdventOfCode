namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day18
    {
        const string _basePath = "Inputs/Day18";
        const string _baseTestName = "Day18Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_CalculatesMinimumNumberOfSteps_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day18("Day18Test1.txt", 12);
            instance.FirstResult.Should().Be(22);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_ProducesFirstCoordinateWhichRendersTheEndUnreachable_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day18("Day18Test1.txt", 12);
            instance.SecondResult.Should().Be((1,6));
        }
    }
}