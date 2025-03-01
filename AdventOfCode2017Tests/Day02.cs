namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day02
    {
        const string _basePath = "Inputs/Day02";
        const string _baseTestName = "Day2Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectSumFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day02($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(18);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part2_OutputsCorrectSumFile2_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day02($"{_baseTestName}2.txt");
            instance.SecondResult.Should().Be(9);
        }
    }
}