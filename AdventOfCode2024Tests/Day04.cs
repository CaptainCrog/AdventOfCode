namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day04
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day04/Day4Test1.txt")]
        public void Part1_ProducesCorrectTotalOfXMAS_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day04("Day4Test1.txt");
            instance.FirstResult.Should().Be(18);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day04/Day4Test1.txt")]
        public void Part2_ProducesCorrectTotalOfXShapedMAS_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day04("Day4Test1.txt");
            instance.SecondResult.Should().Be(9);
        }
    }
}