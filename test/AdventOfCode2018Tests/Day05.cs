namespace AdventOfCode2018Tests
{
    [TestClass]
    public class Day05
    {
        const string _basePath = "Inputs/Day05";
        const string _baseTestName = "Day5Test";

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectAnswerFile1_IsTrue()
        {
            var instance = new AdventOfCode2018.Problems.Day05($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(10);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_OutputsCorrectAnswerFile1_IsTrue()
        {
            var instance = new AdventOfCode2018.Problems.Day05($"{_baseTestName}1.txt");
            instance.SecondResult.Should().Be(4);
        }
    }
}