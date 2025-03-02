namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day16
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day16/Day16Test1.txt")]
        public void Part1_FindsLowestScoreFile1_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day16("Day16Test1.txt");
            instance.FirstResult.Should().Be(11048);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day16/Day16Test2.txt")]
        public void Part1_FindsLowestScoreFile2_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day16("Day16Test2.txt");
            instance.FirstResult.Should().Be(7036);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day16/Day16Test1.txt")]
        public void Part2_CalculatesBestPathsTilesFile1_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day16("Day16Test1.txt");
            instance.SecondResult.Should().Be(64);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day16/Day16Test2.txt")]
        public void Part2_CalculatesBestPathsTilesFile2_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day16("Day16Test2.txt");
            instance.SecondResult.Should().Be(45);
        }
    }
}