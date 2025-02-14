namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day20
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day20/Day20Test1.txt")]
        public void Part1_OutputsCorrectSmallestIPAddressValues_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day20("Day20Test1.txt", 9);
            instance.FirstResult.Should().Be(3);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day20/Day20Test1.txt")]
        public void Part2_OutputsCorrectValidIPAddressCount_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day20("Day20Test1.txt", 9);
            instance.SecondResult.Should().Be(2);
        }
    }
}