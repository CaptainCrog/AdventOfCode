namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day21
    {
        const string _basePath = "Inputs/Day21";
        const string _baseTestName = "Day21Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectSmallestIPAddressValues_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day21($"{_baseTestName}1.txt", "abcde", "decab");
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
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part2_OutputsCorrectSmallestIPAddressValues_IsTrue(string partTwoString, int expectedResult)
        {
            var instance = new AdventOfCode2016.Problems.Day21($"{_baseTestName}2.txt", "abcde", partTwoString);
            instance.SecondResult.IndexOf('a').Should().Be(expectedResult);
        }
    }
}