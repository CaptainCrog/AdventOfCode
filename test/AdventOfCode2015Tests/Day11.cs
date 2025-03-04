namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day11
    {
        const string _basePath = "Inputs/Day11";
        const string _baseTestName = "Day11Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesCorrectNextPasswordFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day11($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be("abcdffaa");
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_ProducesCorrectNextPasswordFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day11($"{_baseTestName}2.txt");
            instance.FirstResult.Should().Be("ghjaabcc");
        }
    }
}