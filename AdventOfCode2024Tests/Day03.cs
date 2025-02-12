namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day03
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day03/Day3Test1.txt")]
        public void Part1_ProducesCorrectMultiplicationOutput_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day03("Day3Test1.txt");
            instance.FirstResult.Should().Be(161);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day03/Day3Test2.txt")]
        public void Part2_ProducesCorrectMultiplicationOutput_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day03("Day3Test2.txt");
            instance.SecondResult.Should().Be(48);
        }
    }
}