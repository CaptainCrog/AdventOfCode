namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day9
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day9/Day9Test1.txt")]
        public void Part1_ProducesCorrectFileChecksum_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day9("Day9Test1.txt");
            instance.FirstResult.Should().Be(1928);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day9/Day9Test1.txt")]
        public void Part2_ProducesCorrectFileChecksum_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day9("Day9Test1.txt");
            instance.SecondResult.Should().Be(2858);
        }
    }
}