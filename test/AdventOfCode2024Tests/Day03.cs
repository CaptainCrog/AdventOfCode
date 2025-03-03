namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day03
    {
        const string _basePath = "Inputs/Day03";
        const string _baseTestName = "Day3Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesCorrectMultiplicationOutput_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day03("Day3Test1.txt");
            instance.FirstResult.Should().Be(161);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part2_ProducesCorrectMultiplicationOutput_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day03("Day3Test2.txt");
            instance.SecondResult.Should().Be(48);
        }
    }
}