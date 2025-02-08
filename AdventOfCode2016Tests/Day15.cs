using System.Drawing;

namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day15
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day15/Day15Test1.txt")]
        public void Part1_OutputsFirstValidTimeToPressButton_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day15("Day15Test1.txt");
            instance.FirstResult.Should().Be(5);
        }
    }
}