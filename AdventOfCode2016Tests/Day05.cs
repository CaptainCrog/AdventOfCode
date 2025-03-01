namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day05
    {
        const string _basePath = "Inputs/Day05";
        const string _baseTestName = "Day5Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectPasswordFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day05($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be("18f47a30");
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_OutputsCorrectPasswordFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day05($"{_baseTestName}1.txt");
            instance.SecondResult.Should().Be("05ace8e3");
        }
    }
}