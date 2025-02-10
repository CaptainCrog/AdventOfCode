using System.Drawing;

namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day17
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day17/Day17Test1.txt")]
        public void Part1And2_OutputsShortestAndLongestPathSizeFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day17("Day17Test1.txt");
            instance.FirstResult.Should().Be("DDRRRD");
            instance.SecondResult.Should().Be(370);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day17/Day17Test2.txt")]
        public void Part1And2_OutputsShortestAndLongestPathSizeFile2_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day17("Day17Test2.txt");
            instance.FirstResult.Should().Be("DDUDRLRRUDRD");
            instance.SecondResult.Should().Be(492);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day17/Day17Test3.txt")]
        public void Part1And2_OutputsShortestAndLongestPathSizeFile3_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day17("Day17Test3.txt");
            instance.FirstResult.Should().Be("DRURDRUDDLLDLUURRDULRLDUUDDDRR");
            instance.SecondResult.Should().Be(830);
        }
    }
}