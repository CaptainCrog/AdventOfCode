namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day3
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day3/Day3Test1.txt")]
        public void Part1_OutputsCorrectTriangleCountFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day3("Day3Test1.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day3/Day3Test2.txt")]
        public void Part1_OutputsCorrectTriangleCountFile2_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day3("Day3Test2.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day3/Day3Test3.txt")]
        public void Part1_OutputsCorrectTriangleCountFile3_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day3("Day3Test3.txt");
            instance.FirstResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day3/Day3Test4.txt")]
        public void Part1_OutputsCorrectTriangleCountFile4_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day3("Day3Test4.txt");
            instance.FirstResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day3/Day3Test5.txt")]
        public void Part1_OutputsCorrectTriangleCountFile5_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day3("Day3Test5.txt");
            instance.FirstResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day3/Day3Test6.txt")]
        public void Part2_OutputsCorrectTriangleCountFile6_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day3("Day3Test6.txt");
            instance.SecondResult.Should().Be(6);
        }
    }
}