using System.Drawing;

namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day13
    {
        const string _basePath = "Inputs/Day13";
        const string _baseTestName = "Day13Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectPathSteps_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day13($"{_baseTestName}1.txt", new Point() { X = 7, Y = 4 });
            instance.FirstResult.Should().Be(11);
        }
    }
}