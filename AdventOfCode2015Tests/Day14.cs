namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day14
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day14/Day14Test1.txt")]
        public void Part1_ProducesLargestReindeerDistance_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day14("Day14Test1.txt", 1000);
            instance.FirstResult.Should().Be(1120);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day14/Day14Test1.txt")]
        public void Part2_ProducesLargestReindeerDistance_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day14("Day14Test1.txt", 1000);
            instance.SecondResult.Should().Be(689);
        }
    }
}