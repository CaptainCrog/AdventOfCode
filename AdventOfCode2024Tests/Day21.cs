namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day21
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day21/Day21Test1.txt")]
        public void Part1_ProducesCorrectComplexitySum_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day21("Day21Test1.txt");
            instance.FirstResult.Should().Be(126384);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day21/Day21Test1.txt")]
        public void Part2_ProducesCorrectTotalFor75Blinks_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day21("Day21Test1.txt");
            instance.SecondResult.Should().Be(154115708116294);
        }
    }
}