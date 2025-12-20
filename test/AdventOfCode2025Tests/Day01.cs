namespace AdventOfCode2025Tests
{
    [TestClass]
    public class Day01
    {
        const string _basePath = "Inputs/Day01";
        const string _baseTestName = "Day1Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesCorrectTotalDistanceBetweenLists_IsTrue()
        {
            var instance = new AdventOfCode2025.Problems.Day01("Day1Test1.txt");
            instance.FirstResult.Should().Be(3);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_ProducesCorrectSimilarityScore_IsTrue()
        {
            var instance = new AdventOfCode2025.Problems.Day01("Day1Test1.txt");
            instance.SecondResult.Should().Be(6);
        }
    }
}