namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day11
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day11/Day11Test1.txt")]
        public void Part1_ProducesCorrectNextPasswordFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day11("Day11Test1.txt");
            instance.FirstResult.Should().Be("abcdffaa");
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day11/Day11Test2.txt")]
        public void Part1_ProducesCorrectNextPasswordFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day11("Day11Test2.txt");
            instance.FirstResult.Should().Be("ghjaabcc");
        }
    }
}