namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day12
    {
        const string _basePath = "Inputs/Day12";
        const string _baseTestName = "Day12Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_CalculatesCorrectValueFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(6);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_CalculatesCorrectValueFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12($"{_baseTestName}2.txt");
            instance.FirstResult.Should().Be(6);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part1_CalculatesCorrectValueFile3_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12($"{_baseTestName}3.txt");
            instance.FirstResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}4.txt")]
        public void Part1_CalculatesCorrectValueFile4_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12($"{_baseTestName}4.txt");
            instance.FirstResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}5.txt")]
        public void Part1_CalculatesCorrectValueFile5_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12($"{_baseTestName}5.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}6.txt")]
        public void Part1_CalculatesCorrectValueFile6_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12($"{_baseTestName}6.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}7.txt")]
        public void Part1_CalculatesCorrectValueFile7_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12($"{_baseTestName}7.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}8.txt")]
        public void Part1_CalculatesCorrectValueFile8_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12($"{_baseTestName}8.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}9.txt")]
        public void Part1_CalculatesCorrectValueFile9_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12($"{_baseTestName}9.txt");
            instance.FirstResult.Should().Be(171);
        }



        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_CalculatesCorrectValueFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12($"{_baseTestName}1.txt");
            instance.SecondResult.Should().Be(6);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}10.txt")]
        public void Part2_CalculatesCorrectBulkDiscountPriceFile10_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12($"{_baseTestName}10.txt");
            instance.SecondResult.Should().Be(4);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}11.txt")]
        public void Part2_CalculatesCorrectBulkDiscountPriceFile11_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12($"{_baseTestName}11.txt");
            instance.SecondResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}12.txt")]
        public void Part2_CalculatesCorrectBulkDiscountPriceFile12_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12($"{_baseTestName}12.txt");
            instance.SecondResult.Should().Be(6);
        }
    }
}