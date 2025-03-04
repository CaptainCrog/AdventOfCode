namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day09
    {
        const string _basePath = "Inputs/Day09";
        const string _baseTestName = "Day9Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectStringLengthFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day09($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(6);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_OutputsCorrectStringLengthFile2_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day09($"{_baseTestName}2.txt");
            instance.FirstResult.Should().Be(7);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part1_OutputsCorrectStringLengthFile3_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day09($"{_baseTestName}3.txt");
            instance.FirstResult.Should().Be(9);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}4.txt")]
        public void Part1_OutputsCorrectStringLengthFile4_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day09($"{_baseTestName}4.txt");
            instance.FirstResult.Should().Be(11);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}5.txt")]
        public void Part1_OutputsCorrectStringLengthFile5_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day09($"{_baseTestName}5.txt");
            instance.FirstResult.Should().Be(6);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}6.txt")]
        public void Part1_OutputsCorrectStringLengthFile6_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day09($"{_baseTestName}6.txt");
            instance.FirstResult.Should().Be(18);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part2_OutputsCorrectStringLengthFile3_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day09($"{_baseTestName}3.txt");
            instance.SecondResult.Should().Be(9);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}6.txt")]
        public void Part2_OutputsCorrectStringLengthFile6_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day09($"{_baseTestName}6.txt");
            instance.SecondResult.Should().Be(20);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}7.txt")]
        public void Part2_OutputsCorrectStringLengthFile7_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day09($"{_baseTestName}7.txt");
            instance.SecondResult.Should().Be(241920);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}8.txt")]
        public void Part2_OutputsCorrectStringLengthFile8_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day09($"{_baseTestName}8.txt");
            instance.SecondResult.Should().Be(445);
        }
    }
}