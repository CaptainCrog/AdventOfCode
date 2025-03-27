namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day20
    {
        const string _basePath = "Inputs/Day20";
        const string _baseTestName = "Day20Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectValueFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day20($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part2_OutputsCorrectValueFile2_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day20($"{_baseTestName}2.txt");
            instance.SecondResult.Should().Be(1);
        }
    }
}