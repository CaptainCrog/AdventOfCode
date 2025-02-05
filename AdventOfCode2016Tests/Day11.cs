namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day11
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day11/Day11Test1.txt")]
        public void Part1_OutputsCorrectStepCount_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day11("Day11Test1.txt");
            instance.FirstResult.ResultValue.Should().Be(11);
        }
    }
}