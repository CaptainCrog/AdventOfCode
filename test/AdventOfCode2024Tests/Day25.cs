namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day25
    {
        const string _basePath = "Inputs/Day25";
        const string _baseTestName = "Day25Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesCorrectTotal_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day25("Day25Test1.txt");
            instance.FirstResult.Should().Be(3);
        }

    }
}