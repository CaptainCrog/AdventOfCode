using System.Drawing;

namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day18
    {
        const string _basePath = "Inputs/Day18";
        const string _baseTestName = "Day18Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectSafeTileCountFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day18($"{_baseTestName}1.txt", 3);
            instance.FirstResult.Should().Be(6);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_OutputsCorrectSafeTileCountFile2_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day18($"{_baseTestName}2.txt", 10);
            instance.FirstResult.Should().Be(38);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_OutputsCorrectSafeTileCountFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day18($"{_baseTestName}1.txt", 3);
            instance.SecondResult.Should().Be(600001);
        }


        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part2_OutputsCorrectSafeTileCountFile2_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day18($"{_baseTestName}2.txt", 10);
            instance.SecondResult.Should().Be(1935478);
        }

    }
}