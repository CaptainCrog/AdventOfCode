namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day25
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day25/Day25Test1.txt")]
        public void Part1_ProducesCorrectTotal_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day25("Day25Test1.txt");
            instance.FirstResult.Should().Be(3);
        }

    }
}