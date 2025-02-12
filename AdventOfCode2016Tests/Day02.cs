namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day02
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day02/Day2Test1.txt")]
        public void Part1_OutputsCorrectKeyCodeFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day02("Day2Test1.txt");
            instance.FirstResult.Should().Be(1985);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day02/Day2Test1.txt")]
        public void Part2_OutputsCorrectKeyCodeFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day02("Day2Test1.txt");
            instance.SecondResult.Should().Be("5DB3");
        }
    }
}