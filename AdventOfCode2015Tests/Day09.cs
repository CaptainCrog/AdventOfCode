namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day09
    {
        const string _prefix = "Inputs/Day09/";
        [TestMethod]
        [DeploymentItem("Inputs/Day09/Day9Test1.txt")]
        public void Part1_ProducesShortestRoute_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day09("Day9Test1.txt");
            instance.FirstResult.Should().Be(605);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day09/Day9Test1.txt")]
        public void Part2_ProducesLongestRoute_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day09("Day9Test1.txt");
            instance.SecondResult.Should().Be(982);
        }
    }
}