namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day19
    {
        const string _basePath = "Inputs/Day19";
        const string _baseTestName = "Day19Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesCorrectNumberOfDistinctCalibrationsFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day19($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(4);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_ProducesCorrectNumberOfDistinctCalibrationsFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day19($"{_baseTestName}2.txt");
            instance.FirstResult.Should().Be(7);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part2_ProducesCorrectNumberOfStepsToGetToMedicineMoleculeFile3_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day19($"{_baseTestName}3.txt");
            instance.SecondResult.Should().Be(2);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}4.txt")]
        public void Part2_ProducesCorrectNumberOfStepsToGetToMedicineMoleculeFile4_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day19($"{_baseTestName}4.txt");
            instance.SecondResult.Should().Be(5);
        }
    }
}