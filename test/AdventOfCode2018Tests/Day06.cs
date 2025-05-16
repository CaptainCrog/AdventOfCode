namespace AdventOfCode2018Tests
{
    [TestClass]
    public class Day06
    {
        const string _basePath = "Inputs/Day06";
        const string _baseTestName = "Day6Test";

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectAnswerFile1_IsTrue()
        {
            var instance = new AdventOfCode2018.Problems.Day06($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(17);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_OutputsCorrectAnswerFile1_IsTrue()
        {
            var instance = new AdventOfCode2018.Problems.Day06($"{_baseTestName}1.txt");
            instance.SecondResult.Should().Be(4);
        }
    }
}