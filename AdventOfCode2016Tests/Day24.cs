namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day24
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day24/Day24Test1.txt")]
        public void Part1_OutputsCorrectNumberOfSteps_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day24("Day24Test1.txt");
            instance.FirstResult.Should().Be(14);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day24/Day24Test1.txt")]
        public void Part2_OutputsCorrectNumberOfSteps_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day24("Day24Test1.txt");
            instance.SecondResult.Should().Be(20);
        }
    }
}