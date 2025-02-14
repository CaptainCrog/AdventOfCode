namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day21
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day21/Day21Test1.txt")]
        public void Part1_OutputsCorrectSmallestIPAddressValues_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day21("Day21Test1.txt", "abcde");
            instance.FirstResult.Should().Be("decab");
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day21/Day21Test1.txt")]
        public void Part2_OutputsCorrectValidIPAddressCount_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day21("Day21Test1.txt", "abcde");
            instance.SecondResult.Should().Be("");
        }
    }
}