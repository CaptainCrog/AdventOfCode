namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day11
    {
        const string _basePath = "Inputs/Day11";
        const string _baseTestName = "Day11Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectValueFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day11($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(3);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_OutputsCorrectHexStringFile2_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day11($"{_baseTestName}2.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part1_OutputsCorrectHexStringFile3_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day11($"{_baseTestName}3.txt");
            instance.FirstResult.Should().Be(2);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}4.txt")]
        public void Part1_OutputsCorrectHexStringFile4_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day11($"{_baseTestName}4.txt");
            instance.FirstResult.Should().Be(3);
        }
    }
}