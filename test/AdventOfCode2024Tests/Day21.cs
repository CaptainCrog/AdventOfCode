namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day21
    {
        const string _basePath = "Inputs/Day21";
        const string _baseTestName = "Day21Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesCorrectComplexitySum_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day21("Day21Test1.txt");
            instance.FirstResult.Should().Be(126384);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_ProducesCorrectTotalFor75Blinks_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day21("Day21Test1.txt");
            instance.SecondResult.Should().Be(154115708116294);
        }
    }
}