namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day12
    {
        const string _basePath = "Inputs/Day12";
        const string _baseTestName = "Day12Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectRegisterOutput_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day12($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(42);
        }
    }
}