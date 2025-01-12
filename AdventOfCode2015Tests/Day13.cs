namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day13
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day13/Day13Test1.txt")]
        public void Part1_CalculatesOptimalSeatingArrangement_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day13("Day13Test1.txt");
            instance.FirstResult.Should().Be(330);
        }
    }
}