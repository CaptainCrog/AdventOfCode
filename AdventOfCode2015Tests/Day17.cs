namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day17
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day17/Day17Test1.txt")]
        public void Part1_ProducesCorrectStringOutput_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day17("Day17Test1.txt", 25);
            instance.FirstResult.Should().Be(4);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day17/Day17Test1.txt")]
        public void Part2_ProducesCorrectLowestInitialValue_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day17("Day17Test1.txt", 25);
            instance.SecondResult.Should().Be(3);
        }
    }
}