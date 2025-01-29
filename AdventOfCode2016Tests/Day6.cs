namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day6
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day6/Day6Test1.txt")]
        public void Part1_OutputsCorrectPasswordFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day6("Day6Test1.txt");
            instance.FirstResult.ResultValue.Should().Be("easter");
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day6/Day6Test1.txt")]
        public void Part2_OutputsCorrectPasswordFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day6("Day6Test1.txt");
            instance.SecondResult.ResultValue.Should().Be("advent");
        }
    }
}