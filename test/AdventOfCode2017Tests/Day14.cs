namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day14
    {
        const string _basePath = "Inputs/Day14";
        const string _baseTestName = "Day14Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectValueFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day14($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(8108);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_OutputsCorrectValueFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day14($"{_baseTestName}1.txt");
            instance.SecondResult.Should().Be("10");
        }
    }
}