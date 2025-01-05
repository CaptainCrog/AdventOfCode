namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day2
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day2/Day2Test1.txt")]
        public void Part1_ProducesCorrectNumberOfSafeReportsWithoutDampener_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day2("Day2Test1.txt");
            instance.FirstResult.Should().Be(2);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day2/Day2Test1.txt")]
        public void Part2_ProducesCorrectNumberOfSafeReportsWithDampener_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day2("Day2Test1.txt");
            instance.SecondResult.Should().Be(4);
        }
    }
}