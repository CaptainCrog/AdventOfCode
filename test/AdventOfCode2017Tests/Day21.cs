namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day21
    {
        const string _basePath = "Inputs/Day21";
        const string _baseTestName = "Day21Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectPixelCountFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day21($"{_baseTestName}1.txt", 2);
            instance.FirstResult.Should().Be(12);
        }
    }
}