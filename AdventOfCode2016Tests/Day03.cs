namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day03
    {
        const string _basePath = "Inputs/Day03";
        const string _baseTestName = "Day3Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectTriangleCountFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day03($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_OutputsCorrectTriangleCountFile2_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day03($"{_baseTestName}2.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part1_OutputsCorrectTriangleCountFile3_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day03($"{_baseTestName}3.txt");
            instance.FirstResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}4.txt")]
        public void Part1_OutputsCorrectTriangleCountFile4_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day03($"{_baseTestName}4.txt");
            instance.FirstResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}5.txt")]
        public void Part1_OutputsCorrectTriangleCountFile5_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day03($"{_baseTestName}5.txt");
            instance.FirstResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}6.txt")]
        public void Part2_OutputsCorrectTriangleCountFile6_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day03($"{_baseTestName}6.txt");
            instance.SecondResult.Should().Be(6);
        }
    }
}