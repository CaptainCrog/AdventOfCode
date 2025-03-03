namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day22
    {
        const string _basePath = "Inputs/Day22";
        const string _baseTestName = "Day22Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesCorrect2000thSecretNumber_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day22("Day22Test1.txt");
            instance.FirstResult.Should().Be(37327623);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part2_ProducesCorrectTotalBananas_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day22("Day22Test2.txt");
            instance.SecondResult.Should().Be(23);
        }
    }
}