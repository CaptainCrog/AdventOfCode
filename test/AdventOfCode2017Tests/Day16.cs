namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day16
    {
        const string _basePath = "Inputs/Day16";
        const string _baseTestName = "Day16Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectProgramListFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day16($"{_baseTestName}1.txt", ['a','b','c','d','e']);
            instance.FirstResult.Should().Be("baedc");
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_OutputsCorrectValueFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day16($"{_baseTestName}1.txt", ['a', 'b', 'c', 'd', 'e']);
            instance.SecondResult.Should().Be("abcde");
        }
    }
}