namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day22
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day22/Day22Test1.txt")]
        public void Part1_ProducesCorrect2000thSecretNumber_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day22("Day22Test1.txt");
            instance.FirstResult.Should().Be(37327623);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day22/Day22Test2.txt")]
        public void Part2_ProducesCorrectTotalBananas_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day22("Day22Test2.txt");
            instance.SecondResult.Should().Be(23);
        }
    }
}