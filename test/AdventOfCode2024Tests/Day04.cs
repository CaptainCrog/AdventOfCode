namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day04
    {
        const string _basePath = "Inputs/Day04";
        const string _baseTestName = "Day4Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesCorrectTotalOfXMAS_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day04("Day4Test1.txt");
            instance.FirstResult.Should().Be(18);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_ProducesCorrectTotalOfXShapedMAS_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day04("Day4Test1.txt");
            instance.SecondResult.Should().Be(9);
        }
    }
}