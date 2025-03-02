namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day04
    {
        const string _basePath = "Inputs/Day04";
        const string _baseTestName = "Day4Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectTriangleCountFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day04($"{_baseTestName}1.txt", "");
            instance.FirstResult.Should().Be(123);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_OutputsCorrectTriangleCountFile2_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day04($"{_baseTestName}2.txt", "");
            instance.FirstResult.Should().Be(987);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part1_OutputsCorrectTriangleCountFile3_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day04($"{_baseTestName}3.txt", "");
            instance.FirstResult.Should().Be(404);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}4.txt")]
        public void Part1_OutputsCorrectTriangleCountFile4_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day04($"{_baseTestName}4.txt", "");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}5.txt")]
        public void Part1_OutputsCorrectTriangleCountFile5_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day04($"{_baseTestName}5.txt", "");
            instance.FirstResult.Should().Be(1514);
        }
    }
}