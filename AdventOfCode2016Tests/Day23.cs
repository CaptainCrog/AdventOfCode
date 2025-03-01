namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day23
    {
        const string _basePath = "Inputs/Day23";
        const string _baseTestName = "Day23Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectValueAtRegisterA_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day23($"{_baseTestName}1.txt", 0);
            instance.FirstResult.Should().Be(3);
        }
    }
}