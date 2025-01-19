namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day20
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day20/Day20Test1.txt")]
        public void Part1_ProducesCorrectTotalOfCheats_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day20("Day20Test1.txt");
            instance.FirstResult.Should().Be(6);
        }
        //No example for Part 2 to test against
}