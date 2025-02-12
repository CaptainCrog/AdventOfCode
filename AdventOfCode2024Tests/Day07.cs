namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day07
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day07/Day7Test1.txt")]
        public void Part1_ProducesCorrectCalibrationResult_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day07("Day7Test1.txt");
            instance.FirstResult.Should().Be(3749);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day07/Day7Test1.txt")]
        public void Part2_ProducesCorrectCalibrationResultTotal_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day07("Day7Test1.txt");
            instance.SecondResult.Should().Be(11387);
        }
    }
}