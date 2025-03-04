namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day20
    {
        const string _basePath = "Inputs/Day20";
        const string _baseTestName = "Day20Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesCorrectTotalOfCheats_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day20($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(6);
        }
        //No example for Part 2 to test against
    }
}