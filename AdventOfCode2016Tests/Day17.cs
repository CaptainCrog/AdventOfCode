using System.Drawing;

namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day17
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day17/Day17Test1.txt")]
        public void Part1_OutputsCorrectShortestPathDirectionsFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day17("Day17Test1.txt");
            instance.FirstResult.Should().Be("DDRRRD");
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day17/Day17Test2.txt")]
        public void Part1_OutputsCorrectShortestPathDirectionsFile2_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day17("Day17Test2.txt");
            instance.FirstResult.Should().Be("DDUDRLRRUDRD");
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day17/Day17Test3.txt")]
        public void Part1_OutputsCorrectShortestPathDirectionsFile3_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day17("Day17Test3.txt");
            instance.FirstResult.Should().Be("DRURDRUDDLLDLUURRDULRLDUUDDDRR");
        }


        [TestMethod]
        [DeploymentItem("Inputs/Day17/Day17Test1.txt")]
        public void Part2_OutputsLongestPathSizeFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day17("Day17Test1.txt");
            instance.SecondResult.Should().Be(370);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day17/Day17Test2.txt")]
        public void Part2_OutputsLongestPathSizeFile2_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day17("Day17Test2.txt");
            instance.SecondResult.Should().Be(492);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day17/Day17Test3.txt")]
        public void Part2_OutputsLongestPathSizeFile3_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day17("Day17Test3.txt");
            instance.SecondResult.Should().Be(830);
        }
    }
}