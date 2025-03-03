namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day24
    {
        const string _basePath = "Inputs/Day24";
        const string _baseTestName = "Day24Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesCorrectBinaryZValueFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day24($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(99);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_ProducesCorrectWiresToSwap_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day24($"{_baseTestName}1.txt");
            instance.SecondResult.Should().Be(44);
        }
    }
}