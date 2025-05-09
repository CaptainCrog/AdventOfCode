namespace AdventOfCode2018Tests
{
    [TestClass]
    public class Day03
    {
        const string _basePath = "Inputs/Day03";
        const string _baseTestName = "Day3Test";

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectOverlapCountFile1_IsTrue()
        {
            var instance = new AdventOfCode2018.Problems.Day03($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(4);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_OutputsCorrectNonOverlapClaimFile2_IsTrue()
        {
            var instance = new AdventOfCode2018.Problems.Day03($"{_baseTestName}1.txt");
            instance.SecondResult.Should().Be(3);
        }
    }
}