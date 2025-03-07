namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day09
    {
        const string _basePath = "Inputs/Day09";
        const string _baseTestName = "Day9Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectGroupScoreFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day09($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(1);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_OutputsCorrectGroupScoreFile2_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day09($"{_baseTestName}2.txt");
            instance.FirstResult.Should().Be(6);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part1_OutputsCorrectGroupScoreFile3_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day09($"{_baseTestName}3.txt");
            instance.FirstResult.Should().Be(5);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}4.txt")]
        public void Part1_OutputsCorrectGroupScoreFile4_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day09($"{_baseTestName}4.txt");
            instance.FirstResult.Should().Be(16);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}5.txt")]
        public void Part1_OutputsCorrectGroupScoreFile5_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day09($"{_baseTestName}5.txt");
            instance.FirstResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}6.txt")]
        public void Part1_OutputsCorrectGroupScoreFile6_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day09($"{_baseTestName}6.txt");
            instance.FirstResult.Should().Be(9);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}7.txt")]
        public void Part1_OutputsCorrectGroupScoreFile7_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day09($"{_baseTestName}7.txt");
            instance.FirstResult.Should().Be(9);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}8.txt")]
        public void Part1_OutputsCorrectGroupScoreFile8_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day09($"{_baseTestName}8.txt");
            instance.FirstResult.Should().Be(3);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}9.txt")]
        public void Part2_CalculatesCorrectGarbageCharCountFile9_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day09($"{_baseTestName}9.txt");
            instance.SecondResult.Should().Be(0);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}10.txt")]
        public void Part2_CalculatesCorrectGarbageCharCountFile10_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day09($"{_baseTestName}10.txt");
            instance.SecondResult.Should().Be(17);
        }


        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}11.txt")]
        public void Part2_CalculatesCorrectGarbageCharCountFile11_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day09($"{_baseTestName}11.txt");
            instance.SecondResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}12.txt")]
        public void Part2_CalculatesCorrectGarbageCharCountFile12_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day09($"{_baseTestName}12.txt");
            instance.SecondResult.Should().Be(2);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}13.txt")]
        public void Part2_CalculatesCorrectGarbageCharCountFile13_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day09($"{_baseTestName}13.txt");
            instance.SecondResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}14.txt")]
        public void Part2_CalculatesCorrectGarbageCharCountFile14_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day09($"{_baseTestName}14.txt");
            instance.SecondResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}15.txt")]
        public void Part2_CalculatesCorrectGarbageCharCountFile15_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day09($"{_baseTestName}15.txt");
            instance.SecondResult.Should().Be(10);
        }
    }
}