namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day07
    {
        const string _basePath = "Inputs/Day07";
        const string _baseTestName = "Day7Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_CompletesWithCorrectStepCountFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day07($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be("tknk");
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_CompletesWithCorrectStepCountFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day07($"{_baseTestName}1.txt");
            instance.SecondResult.Should().Be(60);
        }
    }
}