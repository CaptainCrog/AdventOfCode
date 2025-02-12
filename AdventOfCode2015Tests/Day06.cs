namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day06
    {
        const string _prefix = "Inputs/Day06/";

        [TestMethod]
        [DeploymentItem($"{_prefix}Day6Test1.txt")]
        public void Part1_SetsCorrectLightsFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day06("Day6Test1.txt");
            instance.FirstResult.Should().Be(1000000);
        }
        [TestMethod]
        [DeploymentItem($"{_prefix}Day6Test2.txt")]
        public void Part1_SetsCorrectLightsFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day06("Day6Test2.txt");
            instance.FirstResult.Should().Be(1000);
        }
        [TestMethod]
        [DeploymentItem($"{_prefix}Day6Test3.txt")]
        public void Part1_SetsCorrectLightsFile3_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day06("Day6Test3.txt");
            instance.FirstResult.Should().Be(999996);
        }

        [TestMethod]
        [DeploymentItem($"{_prefix}Day6Test4.txt")]
        public void Part2_SetsCorrectBrightnessFile4_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day06("Day6Test4.txt");
            instance.SecondResult.Should().Be(1);
        }

        [TestMethod]
        [DeploymentItem($"{_prefix}Day6Test5.txt")]
        public void Part2_SetsCorrectBrightnessFile5_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day06("Day6Test5.txt");
            instance.SecondResult.Should().Be(2000000);
        }
    }
}