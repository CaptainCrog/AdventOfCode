namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day02
    {
        const string _basePath = "Inputs/Day02";
        const string _baseTestName = "Day2Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectKeyCodeFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day02($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(1985);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_OutputsCorrectKeyCodeFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day02($"{_baseTestName}1.txt");
            instance.SecondResult.Should().Be("5DB3");
        }
    }
}