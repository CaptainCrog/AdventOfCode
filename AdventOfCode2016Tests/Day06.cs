namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day06
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day06/Day6Test1.txt")]
        public void Part1_OutputsCorrectPasswordFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day06("Day6Test1.txt");
            instance.FirstResult.Should().Be("easter");
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day06/Day6Test1.txt")]
        public void Part2_OutputsCorrectPasswordFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day06("Day6Test1.txt");
            instance.SecondResult.Should().Be("advent");
        }
    }
}