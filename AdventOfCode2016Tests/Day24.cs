namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day24
    {
        const string _basePath = "Inputs/Day24";
        const string _baseTestName = "Day24Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectNumberOfSteps_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day24($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(14);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_OutputsCorrectNumberOfSteps_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day24($"{_baseTestName}1.txt");
            instance.SecondResult.Should().Be(20);
        }
    }
}