namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day20
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day20/Day20Test1.txt")]
        public void Part1_ProducesCorrectTotalOfCheats_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day20("Day20Test1.txt", 50);
            instance.FirstResult.Should().Be(1);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day20/Day20Test1.txt")]
        public void Part2_ProducesCorrectTotalOfCheats_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day20("Day20Test1.txt", 50);
            instance.SecondResult.Should().Be(285);
        }
    }
}