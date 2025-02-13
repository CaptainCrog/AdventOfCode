namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day20
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day20/Day20Test1.txt")]
        public void Part1_OutputsCorrectIPAddressValues_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day20("Day20Test1.txt", 9);
            instance.FirstResult.Should().Be(39);
        }

    }
}