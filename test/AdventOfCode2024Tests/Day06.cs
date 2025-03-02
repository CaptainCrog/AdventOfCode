namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day06
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day06/Day6Test1.txt")]
        public void Part1_ProducesCorrectTotalOfDistinctLocations_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day06("Day6Test1.txt");
            instance.FirstResult.Should().Be(41);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day06/Day6Test1.txt")]
        public void Part2_ProducesCorrectTotalOfInfiniteLoopPositions_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day06("Day6Test1.txt");
            instance.SecondResult.Should().Be(6);
        }
    }
}