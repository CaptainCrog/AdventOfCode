namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day06
    {
        const string _basePath = "Inputs/Day06";
        const string _baseTestName = "Day6Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectPasswordFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day06($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be("easter");
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_OutputsCorrectPasswordFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day06($"{_baseTestName}1.txt");
            instance.SecondResult.Should().Be("advent");
        }
    }
}