namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day10
    {
        const string _basePath = "Inputs/Day10";
        const string _baseTestName = "Day10Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectValueFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day10($"{_baseTestName}1.txt", 5);
            instance.FirstResult.Should().Be(12);
        }

        //[TestMethod]
        //[DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        //public void Part2_OutputsHighestValueFoundDuringProcessingFile1_IsTrue()
        //{
        //    var instance = new AdventOfCode2017.Problems.Day10($"{_baseTestName}1.txt", 5);
        //    instance.SecondResult.Should().Be(10);
        //}
    }
}