namespace AdventOfCode2018Tests
{
    [TestClass]
    public class Day02
    {
        const string _basePath = "Inputs/Day02";
        const string _baseTestName = "Day2Test";

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectChecksumFile1_IsTrue()
        {
            var instance = new AdventOfCode2018.Problems.Day02($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(12);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part2_OutputsCorrectCommonCharsFile2_IsTrue()
        {
            var instance = new AdventOfCode2018.Problems.Day02($"{_baseTestName}2.txt");
            instance.SecondResult.Should().Be("fgij");
        }
    }
}