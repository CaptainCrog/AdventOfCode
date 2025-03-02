namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day10
    {
        const string _basePath = "Inputs/Day10";
        const string _baseTestName = "Day10Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesCorrectValueOutput_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day10($"{_baseTestName}1.txt", 1);
            instance.FirstResult.Should().Be(2);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_ProducesCorrectTrailHeadCountFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day10($"{_baseTestName}2.txt", 1);
            instance.FirstResult.Should().Be(2);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part1_ProducesCorrectTrailHeadCountFile3_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day10($"{_baseTestName}3.txt", 1);
            instance.FirstResult.Should().Be(4);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}4.txt")]
        public void Part1_ProducesCorrectTrailHeadCountFile4_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day10($"{_baseTestName}4.txt", 1);
            instance.FirstResult.Should().Be(6);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}5.txt")]
        public void Part1_ProducesCorrectTrailHeadCountFile5_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day10($"{_baseTestName}5.txt", 1);
            instance.FirstResult.Should().Be(6);
        }
        // No part 2 tests as it builds off the original functionality again which is already covered by part 1 tests
    }
}