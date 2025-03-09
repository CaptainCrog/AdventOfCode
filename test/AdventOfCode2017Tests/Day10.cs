namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day10
    {
        const string _basePath = "Inputs/Day10";
        const string _baseTestName = "Day10Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectValueFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day10($"{_baseTestName}1.txt", 5);
            instance.FirstResult.Should().Be(12);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part2_OutputsCorrectHexStringFile2_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day10($"{_baseTestName}2.txt", 256);
            instance.SecondResult.Should().Be("a2582a3a0e66e6e86e3812dcb672a272");
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part2_OutputsCorrectHexStringFile3_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day10($"{_baseTestName}3.txt", 256);
            instance.SecondResult.Should().Be("33efeb34ea91902bb2f59c9920caa6cd");
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}4.txt")]
        public void Part2_OutputsCorrectHexStringFile4_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day10($"{_baseTestName}4.txt", 256);
            instance.SecondResult.Should().Be("3efbe78a8d82f29979031a4aa0b16a9d");
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}5.txt")]
        public void Part2_OutputsCorrectHexStringFile5_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day10($"{_baseTestName}5.txt", 256);
            instance.SecondResult.Should().Be("63960835bcdc130f0b66d7ff4f6a5a8e");
        }
    }
}