namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day10
    {
        const string _basePath = "Inputs/Day10";
        const string _baseTestName = "Day10Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectStringLengthFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day10($"{_baseTestName}1.txt", (5,2));
            instance.FirstResult.Should().Be(2);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_OutputsCorrectStringLengthFile3_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day10($"{_baseTestName}1.txt", (5, 2));
            instance.SecondResult.Should().Be(30);
        }
    }
}