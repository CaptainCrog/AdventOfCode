namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day14
    {
        const string _basePath = "Inputs/Day14";
        const string _baseTestName = "Day14Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesLargestReindeerDistance_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day14($"{_baseTestName}1.txt", 1000);
            instance.FirstResult.Should().Be(1120);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_ProducesLargestReindeerDistance_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day14($"{_baseTestName}1.txt", 1000);
            instance.SecondResult.Should().Be(689);
        }
    }
}