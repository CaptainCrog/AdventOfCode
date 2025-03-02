namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day11
    {
        const string _basePath = "Inputs/Day11";
        const string _baseTestName = "Day11Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectStepCount_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day11($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(11);
        }
    }
}