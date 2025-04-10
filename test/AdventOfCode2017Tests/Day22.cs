namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day22
    {
        const string _basePath = "Inputs/Day22";
        const string _baseTestName = "Day22Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectBurstCountFile1_Example1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day22($"{_baseTestName}1.txt", 7);
            instance.FirstResult.Should().Be(5);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectBurstCountFile1_Example2_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day22($"{_baseTestName}1.txt", 70);
            instance.FirstResult.Should().Be(41);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectBurstCountFile1_Example3_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day22($"{_baseTestName}1.txt", 10000);
            instance.FirstResult.Should().Be(5587);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectBurstCountFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day22($"{_baseTestName}1.txt", 1);
            instance.SecondResult.Should().Be(2511944);
        }
    }
}