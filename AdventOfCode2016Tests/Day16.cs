using System.Drawing;

namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day16
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day16/Day16Test1.txt")]
        public void Part1_OutputsCorrectChecksumFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day16("Day16Test1.txt", 20);
            instance.FirstResult.Should().Be("01100");
        }
    }
}