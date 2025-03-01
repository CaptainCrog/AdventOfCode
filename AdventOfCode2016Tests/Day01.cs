namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day01
    {
        const string _basePath = "Inputs/Day01";
        const string _baseTestName = "Day1Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectBlockDistanceFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day01($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(5);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_OutputsCorrectBlockDistanceFile2_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day01($"{_baseTestName}2.txt");
            instance.FirstResult.Should().Be(2);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part1_OutputsCorrectBlockDistanceFile3_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day01($"{_baseTestName}3.txt");
            instance.FirstResult.Should().Be(12);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}4.txt")]
        public void Part2_OutputsCorrectBlockDistanceFile4_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day01($"{_baseTestName}4.txt");
            instance.SecondResult.Should().Be(4);
        }
    }
}