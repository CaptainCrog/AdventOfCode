namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day05
    {
        const string _basePath = "Inputs/Day05";
        const string _baseTestName = "Day5Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_CompletesWithCorrectStepCountFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day05($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(5);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_CompletesWithCorrectStepCountFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day05($"{_baseTestName}1.txt");
            instance.SecondResult.Should().Be(10);
        }
    }
}