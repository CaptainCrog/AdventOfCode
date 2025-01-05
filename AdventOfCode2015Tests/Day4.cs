namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day4
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day4/Day4Test1.txt")]
        public void Part1_ProducesCorrectTotalOfXMAS_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day4("Day4Test1.txt");
            instance.FirstResult.Should().Be(18);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day4/Day4Test1.txt")]
        public void Part2_ProducesCorrectTotalOfXShapedMAS_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day4("Day4Test1.txt");
            instance.SecondResult.Should().Be(9);
        }
    }
}