namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day24
    {
        const string _basePath = "Inputs/Day24";
        const string _baseTestName = "Day24Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesCorrectBinaryZValueFile1_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day24("Day24Test1.txt", "z06");
            instance.FirstResult.Should().Be(4);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_ProducesCorrectBinaryZValueFile2_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day24("Day24Test2.txt", "z06");
            instance.FirstResult.Should().Be(2024);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part2_ProducesCorrectWiresToSwap_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day24("Day24Test3.txt", "z06");
            instance.SecondResult.Should().Be("z00,z01,z02,z05");
        }
    }
}