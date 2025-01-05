namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day6
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day6/Day6Test1.txt")]
        public void Part1_ProducesCorrectTotalOfDistinctLocations_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day6("Day6Test1.txt");
            instance.FirstResult.Should().Be(41);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day6/Day6Test1.txt")]
        public void Part2_ProducesCorrectTotalOfInfiniteLoopPositions_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day6("Day6Test1.txt");
            instance.SecondResult.Should().Be(6);
        }
    }
}