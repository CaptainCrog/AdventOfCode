namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day20
    {
        const string _basePath = "Inputs/Day20";
        const string _baseTestName = "Day20Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesCorrectTotalOfCheats_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day20("Day20Test1.txt", 50);
            instance.FirstResult.Should().Be(1);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_ProducesCorrectTotalOfCheats_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day20("Day20Test1.txt", 50);
            instance.SecondResult.Should().Be(285);
        }
    }
}