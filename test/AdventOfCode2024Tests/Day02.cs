namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day02
    {
        const string _basePath = "Inputs/Day02";
        const string _baseTestName = "Day2Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesCorrectNumberOfSafeReportsWithoutDampener_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day02("Day2Test1.txt");
            instance.FirstResult.Should().Be(2);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_ProducesCorrectNumberOfSafeReportsWithDampener_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day02("Day2Test1.txt");
            instance.SecondResult.Should().Be(4);
        }
    }
}