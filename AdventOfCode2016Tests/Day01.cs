namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day01
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day01/Day1Test1.txt")]
        public void Part1_OutputsCorrectBlockDistanceFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day01("Day1Test1.txt");
            instance.FirstResult.Should().Be(5);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day01/Day1Test2.txt")]
        public void Part1_OutputsCorrectBlockDistanceFile2_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day01("Day1Test2.txt");
            instance.FirstResult.Should().Be(2);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day01/Day1Test3.txt")]
        public void Part1_OutputsCorrectBlockDistanceFile3_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day01("Day1Test3.txt");
            instance.FirstResult.Should().Be(12);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day01/Day1Test4.txt")]
        public void Part2_OutputsCorrectBlockDistanceFile4_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day01("Day1Test4.txt");
            instance.SecondResult.Should().Be(4);
        }
    }
}