namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day25
    {
        const string _basePath = "Inputs/Day25";
        const string _baseTestName = "Day25Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectChecksumFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day25($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(3);
        }
        //[TestMethod]
        //[DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        //public void Part2_OutputsLargestAndLongestBridgeFile1_IsTrue()
        //{
        //    var instance = new AdventOfCode2017.Problems.Day25($"{_baseTestName}1.txt");
        //    instance.SecondResult.Should().Be(19);
        //}
    }
}