namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day7
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day7/Day7Test1.txt")]
        public void Part1_ProducesCorrectCalibrationResult_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day7("Day7Test1.txt");
            instance.FirstResult.Should().Be(3749);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day7/Day7Test1.txt")]
        public void Part2_ProducesCorrectCalibrationResultTotal_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day7("Day7Test1.txt");
            instance.SecondResult.Should().Be(11387);
        }
    }
}