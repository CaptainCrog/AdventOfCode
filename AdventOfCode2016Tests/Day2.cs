namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day2
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day2/Day2Test1.txt")]
        public void Part1_OutputsCorrectKeyCodeFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day2("Day2Test1.txt");
            instance.FirstResult.Should().Be(1985);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day2/Day1Test2.txt")]
        public void Part1_OutputsCorrectFloorFile2_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day2("Day1Test2.txt");
            instance.FirstResult.Should().Be(2);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day2/Day1Test3.txt")]
        public void Part1_OutputsCorrectFloorFile3_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day2("Day1Test3.txt");
            instance.FirstResult.Should().Be(12);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day2/Day1Test4.txt")]
        public void Part1_OutputsCorrectFloorFile4_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day2("Day1Test4.txt");
            instance.SecondResult.Should().Be(4);
        }
    }
}