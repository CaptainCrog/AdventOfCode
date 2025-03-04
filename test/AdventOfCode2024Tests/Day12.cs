namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day12
    {
        const string _basePath = "Inputs/Day12";
        const string _baseTestName = "Day12Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_CalculatesCorrectAreaFile1_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day12("Day12Test1.txt");
            instance.FirstResult.Should().Be(140);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_CalculatesCorrectAreaFile2_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day12("Day12Test2.txt");
            instance.FirstResult.Should().Be(772);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part1_CalculatesCorrectAreaFile3_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day12("Day12Test3.txt");
            instance.FirstResult.Should().Be(1930);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_CalculatesCorrectBulkDiscountPriceFile1_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day12("Day12Test1.txt");
            instance.SecondResult.Should().Be(80);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part2_CalculatesCorrectBulkDiscountPriceFile2_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day12("Day12Test2.txt");
            instance.SecondResult.Should().Be(436);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}4.txt")]
        public void Part2_CalculatesCorrectBulkDiscountPriceFile4_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day12("Day12Test4.txt");
            instance.SecondResult.Should().Be(236);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}5.txt")]
        public void Part2_CalculatesCorrectBulkDiscountPriceFile5_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day12("Day12Test5.txt");
            instance.SecondResult.Should().Be(368);
        }
    }
}