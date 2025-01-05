namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day19
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day19/Day19Test1.txt")]
        public void Part1_ProducesCorrectNumberOfPossibleDesigns_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day19("Day19Test1.txt");
            instance.FirstResult.Should().Be(6);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day19/Day19Test1.txt")]
        public void Part2_ProducesCorrectNumberOfPermutationsForEachDesign_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day19("Day19Test1.txt");
            instance.SecondResult.Should().Be(16);
        }
    }
}