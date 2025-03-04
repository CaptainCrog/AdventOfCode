using System.Drawing;

namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day15
    {
        const string _basePath = "Inputs/Day15";
        const string _baseTestName = "Day15Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsFirstValidTimeToPressButton_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day15($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(5);
        }
    }
}