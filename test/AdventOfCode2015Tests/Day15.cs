namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day15
    {
        const string _basePath = "Inputs/Day15";
        const string _baseTestName = "Day15Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesBestScore_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day15($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(62842880);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_ProducesBestScoreFor500Calories_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day15($"{_baseTestName}1.txt");
            instance.SecondResult.Should().Be(57600000);
        }
    }
}