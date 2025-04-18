namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day03
    {
        const string _basePath = "Inputs/Day03";
        const string _baseTestName = "Day3Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_CalculatesDistinctHousePositionsFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day03($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(2);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_CalculatesDistinctHousePositionsFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day03($"{_baseTestName}2.txt");
            instance.FirstResult.Should().Be(4);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part1_CalculatesDistinctHousePositionsFile3_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day03($"{_baseTestName}3.txt");
            instance.FirstResult.Should().Be(2);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}4.txt")]
        public void Part2_CalculatesDistinctHousePositionsFile4_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day03($"{_baseTestName}4.txt");
            instance.SecondResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part2_CalculatesDistinctHousePositionsFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day03($"{_baseTestName}2.txt");
            instance.SecondResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part2_CalculatesDistinctHousePositionsFile3_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day03($"{_baseTestName}3.txt");
            instance.SecondResult.Should().Be(11);
        }
    }
}