namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day17
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day17/Day17Test1.txt")]
        public void Part1_ProducesCorrectStringOutput_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day17("Day17Test1.txt");
            instance.FirstResult.Should().Be("4,6,3,5,6,3,5,2,1,0");
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day17/Day17Test2.txt")]
        public void Part2_ProducesCorrectLowestInitialValue_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day17("Day17Test2.txt");
            instance.SecondResult.Should().Be(117440);
        }
    }
}