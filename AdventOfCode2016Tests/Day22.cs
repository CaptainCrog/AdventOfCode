namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day22
    {
        const string _basePath = "Inputs/Day22";
        const string _baseTestName = "Day22Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_FindsSmallestNumberOfSteps_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day22($"{_baseTestName}1.txt");
            instance.SecondResult.Should().Be(7);
        }
    }
}