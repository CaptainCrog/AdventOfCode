namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day1
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day1/Day1Test1.txt")]
        public void Part1_OutputsCorrectFloorFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day1("Day1Test1.txt");
            instance.FirstResult.Should().Be(0);
        }
    }
}