namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day23
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day23/Day23Test1.txt")]
        public void Part1_ProducesCorrectTotal_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day23("Day23Test1.txt");
            instance.FirstResult.Should().Be(7);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day23/Day23Test1.txt")]
        public void Part2_ProducesCorrectPassword_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day23("Day23Test1.txt");
            instance.SecondResult.Should().Be("co,de,ka,ta");
        }
    }
}