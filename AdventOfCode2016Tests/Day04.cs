namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day04
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day04/Day4Test1.txt")]
        public void Part1_OutputsCorrectTriangleCountFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day04("Day4Test1.txt", "");
            instance.FirstResult.Should().Be(123);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day04/Day4Test2.txt")]
        public void Part1_OutputsCorrectTriangleCountFile2_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day04("Day4Test2.txt", "");
            instance.FirstResult.Should().Be(987);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day04/Day4Test3.txt")]
        public void Part1_OutputsCorrectTriangleCountFile3_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day04("Day4Test3.txt", "");
            instance.FirstResult.Should().Be(404);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day04/Day4Test4.txt")]
        public void Part1_OutputsCorrectTriangleCountFile4_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day04("Day4Test4.txt", "");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day04/Day4Test5.txt")]
        public void Part1_OutputsCorrectTriangleCountFil5_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day04("Day4Test5.txt", "");
            instance.FirstResult.Should().Be(1514);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day04/Day4Test6.txt")]
        public void Part2_OutputsCorrectTriangleCountFile6_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day04("Day4Test6.txt", "encrypted");
            instance.SecondResult.Should().Be(343);
        }
    }
}