namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day01
    {
        const string _basePath = "Inputs/Day01";
        const string _baseTestName = "Day1Test";

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectSumFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day01($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(3);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_OutputsCorrectSumFile2_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day01($"{_baseTestName}2.txt");
            instance.FirstResult.Should().Be(4);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part1_OutputsCorrectSumFile3_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day01($"{_baseTestName}3.txt");
            instance.FirstResult.Should().Be(0);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}4.txt")]
        public void Part1_OutputsCorrectSumFile4_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day01($"{_baseTestName}4.txt");
            instance.FirstResult.Should().Be(9);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}5.txt")]
        public void Part2_OutputsCorrectSumFile5_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day01($"{_baseTestName}5.txt");
            instance.SecondResult.Should().Be(6);
        }


        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}6.txt")]
        public void Part2_OutputsCorrectSumFile6_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day01($"{_baseTestName}6.txt");
            instance.SecondResult.Should().Be(0);
        }


        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}7.txt")]
        public void Part2_OutputsCorrectSumFile7_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day01($"{_baseTestName}7.txt");
            instance.SecondResult.Should().Be(4);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}8.txt")]
        public void Part2_OutputsCorrectSumFile8_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day01($"{_baseTestName}8.txt");
            instance.SecondResult.Should().Be(12);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}9.txt")]
        public void Part2_OutputsCorrectSumFile9_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day01($"{_baseTestName}9.txt");
            instance.SecondResult.Should().Be(4);
        }
    }
}