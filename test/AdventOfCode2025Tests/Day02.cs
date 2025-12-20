namespace AdventOfCode2025Tests
{
    [TestClass]
    public class Day02
    {
        const string _basePath = "Inputs/Day02";
        const string _baseTestName = "Day2Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesCorrectTotalDistanceBetweenLists_IsTrue()
        {
            var instance = new AdventOfCode2025.Problems.Day02($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(1227775554);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_ProducesCorrectSimilarityScore_IsTrue()
        {
            var instance = new AdventOfCode2025.Problems.Day02($"{_baseTestName}1.txt");
            instance.SecondResult.Should().Be(4174379265);
        }
    }
}