namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day13
    {
        const string _basePath = "Inputs/Day13";
        const string _baseTestName = "Day13Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_CalculatesOptimalSeatingArrangement_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day13($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(330);
        }
    }
}