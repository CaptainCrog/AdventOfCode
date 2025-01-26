namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day24
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day24/Day24Test1.txt")]
        public void Part1_ProducesCorrectBinaryZValueFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day24("Day24Test1.txt");
            instance.FirstResult.Should().Be(99);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day24/Day24Test1.txt")]
        public void Part2_ProducesCorrectWiresToSwap_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day24("Day24Test1.txt");
            instance.SecondResult.Should().Be(44);
        }
    }
}