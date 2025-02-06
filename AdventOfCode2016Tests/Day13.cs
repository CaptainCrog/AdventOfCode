using System.Drawing;

namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day13
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day13/Day13Test1.txt")]
        public void Part1_OutputsCorrectRegisterOutput_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day13("Day13Test1.txt", new Point() { X = 7, Y = 4 });
            instance.FirstResult.ResultValue.Should().Be(11);
        }
    }
}