namespace AdventOfCode2015Tests
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
            var instance = new AdventOfCode2015.Problems.Day18($"{_baseTestName}1.txt", 4);
            instance.FirstResult.Should().Be(4);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_ProducesFirstCoordinateWhichRendersTheEndUnreachable_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day18($"{_baseTestName}1.txt", 5);
            instance.SecondResult.Should().Be(17);
        }
    }
}