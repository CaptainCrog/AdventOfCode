namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day22
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day22/Day22Test1.txt")]
        public void Part2_FindsSmallestNumberOfSteps_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day22("Day22Test1.txt");
            instance.SecondResult.Should().Be(7);
        }
    }
}