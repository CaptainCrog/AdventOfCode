namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day15
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day15/Day15Test1.txt")]
        public void Part1_ProducesBestScore_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day15("Day15Test1.txt");
            instance.FirstResult.Should().Be(62842880);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day15/Day15Test1.txt")]
        public void Part2_ProducesBestScoreFor500Calories_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day15("Day15Test1.txt");
            instance.SecondResult.Should().Be(57600000);
        }
    }
}