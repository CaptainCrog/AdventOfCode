namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day5
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day5/Day5Test1.txt")]
        public void Part1_OutputsCorrectPasswordFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day5("Day5Test1.txt");
            instance.FirstResult.ResultValue.Should().Be("18f47a30");
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day5/Day5Test1.txt")]
        public void Part2_OutputsCorrectPasswordFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day5("Day5Test1.txt");
            instance.SecondResult.ResultValue.Should().Be("05ace8e3");
        }
    }
}