namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day19
    {
        const string _basePath = "Inputs/Day19";
        const string _baseTestName = "Day19Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectValueFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day19($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be("ABCDEF");
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_OutputsCorrectValueFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day19($"{_baseTestName}1.txt");
            instance.SecondResult.Should().Be(38);
        }
    }
}