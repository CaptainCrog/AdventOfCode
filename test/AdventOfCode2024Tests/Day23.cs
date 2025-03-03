namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day23
    {
        const string _basePath = "Inputs/Day23";
        const string _baseTestName = "Day23Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesCorrectTotal_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day23("Day23Test1.txt");
            instance.FirstResult.Should().Be(7);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_ProducesCorrectPassword_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day23("Day23Test1.txt");
            instance.SecondResult.Should().Be("co,de,ka,ta");
        }
    }
}