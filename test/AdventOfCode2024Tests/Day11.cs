namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day11
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day11/Day11Test1.txt")]
        public void Part1_ProducesCorrectTotalFor25Blinks_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day11("Day11Test1.txt");
            instance.FirstResult.Should().Be(55312);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day11/Day11Test1.txt")]
        public void Part2_ProducesCorrectTotalFor75Blinks_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day11("Day11Test1.txt");
            instance.SecondResult.Should().Be(65601038650482);
        }
    }
}