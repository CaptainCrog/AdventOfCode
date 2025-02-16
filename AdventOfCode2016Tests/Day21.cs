namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day21
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day21/Day21Test1.txt")]
        public void Part1_OutputsCorrectSmallestIPAddressValues_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day21("Day21Test1.txt", "abcde", "decab");
            instance.FirstResult.Should().Be("decab");
            instance.SecondResult.Should().Be("abcde");
        }


        [DataTestMethod]
        [DataRow("abcdefgh", 7)]
        [DataRow("bacdefgh", 0)]
        [DataRow("bcadefgh", 4)]
        [DataRow("bcdaefgh", 1)]
        [DataRow("bcdeafgh", 5)]
        [DataRow("bcdefagh", 2)]
        [DataRow("bcdefgah", 6)]
        [DataRow("bcdefgha", 3)]
        [DeploymentItem("Inputs/Day21/Day21Test2.txt")]
        public void Part2_OutputsCorrectSmallestIPAddressValues_IsTrue(string partTwoString, int expectedResult)
        {
            var instance = new AdventOfCode2016.Problems.Day21("Day21Test2.txt", "abcde", partTwoString);
            instance.SecondResult.IndexOf('a').Should().Be(expectedResult);
        }
    }
}