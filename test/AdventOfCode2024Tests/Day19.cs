namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day19
    {
        const string _basePath = "Inputs/Day19";
        const string _baseTestName = "Day19Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesCorrectNumberOfPossibleDesigns_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day19("Day19Test1.txt");
            instance.FirstResult.Should().Be(6);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_ProducesCorrectNumberOfPermutationsForEachDesign_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day19("Day19Test1.txt");
            instance.SecondResult.Should().Be(16);
        }
    }
}