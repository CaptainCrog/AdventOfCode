namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day02
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day02/Day2Test1.txt")]
        public void Part1_OutputsCorrectSumFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day02("Day2Test1.txt");
            instance.FirstResult.Should().Be(18);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day02/Day2Test2.txt")]
        public void Part1_OutputsCorrectSumFile2_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day02("Day2Test2.txt");
            instance.SecondResult.Should().Be(9);
        }
    }
}