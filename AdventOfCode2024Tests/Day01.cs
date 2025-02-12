namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day01
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day01/Day1Test1.txt")]
        public void Part1_ProducesCorrectTotalDistanceBetweenLists_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day01("Day1Test1.txt");
            instance.FirstResult.Should().Be(11);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day01/Day1Test1.txt")]
        public void Part2_ProducesCorrectSimilarityScore_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day01("Day1Test1.txt");
            instance.SecondResult.Should().Be(31);
        }
    }
}