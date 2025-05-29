namespace AdventOfCode2018Tests
{
    [TestClass]
    public class Day07
    {
        const string _basePath = "Inputs/Day07";
        const string _baseTestName = "Day7Test";

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectAnswerFile1_IsTrue()
        {
            var instance = new AdventOfCode2018.Problems.Day07($"{_baseTestName}1.txt", 0, 2);
            instance.FirstResult.Should().Be("CABDFE");
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_OutputsCorrectAnswerFile1_IsTrue()
        {
            var instance = new AdventOfCode2018.Problems.Day07($"{_baseTestName}1.txt", 0, 2);
            instance.SecondResult.Should().Be(16);
        }
    }
}