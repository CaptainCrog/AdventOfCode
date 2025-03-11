namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day13
    {
        const string _basePath = "Inputs/Day13";
        const string _baseTestName = "Day13Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectValueFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day13($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(24);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_OutputsCorrectValueFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day13($"{_baseTestName}1.txt");
            instance.SecondResult.Should().Be(10);
        }
    }
}