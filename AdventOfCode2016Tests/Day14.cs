using System.Drawing;

namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day14
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day14/Day14Test1.txt")]
        public void Part1_OutputsCorrect64thKey_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day14("Day14Test1.txt");
            instance.FirstResult.Should().Be(22728);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day14/Day14Test1.txt")]
        public void Part2_OutputsCorrect64thKey_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day14("Day14Test1.txt");
            instance.SecondResult.Should().Be(22551);
        }
    }
}