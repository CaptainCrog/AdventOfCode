namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day06
    {
        const string _basePath = "Inputs/Day06";
        const string _baseTestName = "Day6Test";

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_SetsCorrectLightsFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day06($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(1000000);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_SetsCorrectLightsFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day06($"{_baseTestName}2.txt");
            instance.FirstResult.Should().Be(1000);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part1_SetsCorrectLightsFile3_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day06($"{_baseTestName}3.txt");
            instance.FirstResult.Should().Be(999996);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}4.txt")]
        public void Part2_SetsCorrectBrightnessFile4_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day06($"{_baseTestName}4.txt");
            instance.SecondResult.Should().Be(1);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}5.txt")]
        public void Part2_SetsCorrectBrightnessFile5_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day06($"{_baseTestName}5.txt");
            instance.SecondResult.Should().Be(2000000);
        }
    }
}