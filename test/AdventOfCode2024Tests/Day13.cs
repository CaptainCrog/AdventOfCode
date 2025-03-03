namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day13
    {
        const string _basePath = "Inputs/Day13";
        const string _baseTestName = "Day13Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_CalculatesFewestTokens_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day13("Day13Test1.txt");
            instance.FirstResult.Should().Be(480);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_CalculatesFewestTokens_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day13("Day13Test1.txt");
            instance.SecondResult.Should().Be(875318608908);
        }
    }
}