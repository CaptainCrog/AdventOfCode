namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day20
    {
        const string _basePath = "Inputs/Day20";
        const string _baseTestName = "Day20Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectSmallestIPAddressValues_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day20($"{_baseTestName}1.txt", 9);
            instance.FirstResult.Should().Be(3);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_OutputsCorrectValidIPAddressCount_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day20($"{_baseTestName}1.txt", 10);
            instance.SecondResult.Should().Be(2);
        }
    }
}