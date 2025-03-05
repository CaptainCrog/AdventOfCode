namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day08
    {
        const string _basePath = "Inputs/Day08";
        const string _baseTestName = "Day8Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsLargestRegisterFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day08($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(1);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_OutputsHighestValueFoundDuringProcessingFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day08($"{_baseTestName}1.txt");
            instance.SecondResult.Should().Be(10);
        }
    }
}