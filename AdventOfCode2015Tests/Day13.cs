namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day13
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day13/Day13Test1.txt")]
        public void Part1_CalculatesFewestTokens_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day13("Day13Test1.txt");
            instance.FirstResult.Should().Be(480);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day13/Day13Test1.txt")]
        public void Part2_CalculatesFewestTokens_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day13("Day13Test1.txt");
            instance.SecondResult.Should().Be(875318608908);
        }
    }
}