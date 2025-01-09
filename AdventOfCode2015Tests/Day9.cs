namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day9
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day9/Day9Test1.txt")]
        public void Part1_ProducesShortestRoute_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day9("Day9Test1.txt");
            instance.FirstResult.Should().Be(605);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day9/Day9Test1.txt")]
        public void Part2_ProducesLongestRoute_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day9("Day9Test1.txt");
            instance.SecondResult.Should().Be(982);
        }
    }
}