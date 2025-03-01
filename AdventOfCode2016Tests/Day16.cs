using System.Drawing;

namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day16
    {
        const string _basePath = "Inputs/Day16";
        const string _baseTestName = "Day16Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectChecksumFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day16($"{_baseTestName}1.txt", 20);
            instance.FirstResult.Should().Be("01100");
        }
    }
}