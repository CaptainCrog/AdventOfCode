namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day17
    {
        const string _basePath = "Inputs/Day17";
        const string _baseTestName = "Day17Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesCorrectStringOutput_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day17("Day17Test1.txt");
            instance.FirstResult.Should().Be("4,6,3,5,6,3,5,2,1,0");
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part2_ProducesCorrectLowestInitialValue_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day17("Day17Test2.txt");
            instance.SecondResult.Should().Be(117440);
        }
    }
}