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
            instance.FirstResult.ResultValue.Should().Be(1985);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day2/Day2Test1.txt")]
        public void Part2_OutputsCorrectKeyCodeFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day2("Day2Test1.txt");
            instance.SecondResult.ResultValue.Should().Be("5DB3");
        }
    }
}