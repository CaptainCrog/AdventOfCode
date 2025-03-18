namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day17
    {
        const string _basePath = "Inputs/Day17";
        const string _baseTestName = "Day17Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectProgramListFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day17($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(638);
        }
        //[TestMethod]
        //[DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        //public void Part2_OutputsCorrectValueFile1_IsTrue()
        //{
        //    var instance = new AdventOfCode2017.Problems.Day17($"{_baseTestName}1.txt");
        //    instance.SecondResult.Should().Be("abcde");
        //}
    }
}