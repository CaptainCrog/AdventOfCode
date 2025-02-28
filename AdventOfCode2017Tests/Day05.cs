namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day05
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day05/Day5Test1.txt")]
        public void Part1_CompletesWithCorrectStepCountFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day05("Day5Test1.txt");
            instance.FirstResult.Should().Be(5);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day05/Day5Test1.txt")]
        public void Part2_CompletesWithCorrectStepCountFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day05("Day5Test1.txt");
            instance.SecondResult.Should().Be(10);
        }
    }
}