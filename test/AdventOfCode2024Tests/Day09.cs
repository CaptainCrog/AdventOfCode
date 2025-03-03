namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day09
    {
        const string _basePath = "Inputs/Day09";
        const string _baseTestName = "Day9Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesCorrectFileChecksum_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day09("Day9Test1.txt");
            instance.FirstResult.Should().Be(1928);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_ProducesCorrectFileChecksum_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day09("Day9Test1.txt");
            instance.SecondResult.Should().Be(2858);
        }
    }
}