namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day09
    {
        const string _basePath = "Inputs/Day09";
        const string _baseTestName = "Day9Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesShortestRoute_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day09($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(605);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_ProducesLongestRoute_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day09($"{_baseTestName}1.txt");
            instance.SecondResult.Should().Be(982);
        }
    }
}