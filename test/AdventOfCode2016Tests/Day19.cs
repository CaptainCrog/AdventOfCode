using System.Drawing;

namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day19
    {
        const string _basePath = "Inputs/Day19";
        const string _baseTestName = "Day19Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectElfFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day19($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_OutputsCorrectElfFile2_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day19($"{_baseTestName}2.txt");
            instance.FirstResult.Should().Be(73);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_OutputsCorrectElfFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day19($"{_baseTestName}1.txt");
            instance.SecondResult.Should().Be(2);
        }


        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part2_OutputsCorrectElfFile2_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day19($"{_baseTestName}2.txt");
            instance.SecondResult.Should().Be(19);
        }

    }
}