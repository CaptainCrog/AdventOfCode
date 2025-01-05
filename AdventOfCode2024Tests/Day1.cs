namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day1
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day1/Day1Test1.txt")]
        public void Part1_ProducesCorrectTotalDistanceBetweenLists_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day1("Day1Test1.txt");
            instance.FirstResult.Should().Be(11);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day1/Day1Test1.txt")]
        public void Part2_ProducesCorrectSimilarityScore_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day1("Day1Test1.txt");
            instance.SecondResult.Should().Be(31);
        }
    }
}