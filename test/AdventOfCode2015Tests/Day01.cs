namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day01
    {
        const string _basePath = "Inputs/Day01";
        const string _baseTestName = "Day1Test";

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectFloorFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(0);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_OutputsCorrectFloorFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"{_baseTestName}2.txt");
            instance.FirstResult.Should().Be(0);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part1_OutputsCorrectFloorFile3_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"{_baseTestName}3.txt");
            instance.FirstResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}4.txt")]
        public void Part1_OutputsCorrectFloorFile4_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"{_baseTestName}4.txt");
            instance.FirstResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}5.txt")]
        public void Part1_OutputsCorrectFloorFile5_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"{_baseTestName}5.txt");
            instance.FirstResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}6.txt")]
        public void Part1_OutputsCorrectFloorFile6_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"{_baseTestName}6.txt");
            instance.FirstResult.Should().Be(-1);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}7.txt")]
        public void Part1_OutputsCorrectFloorFile7_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"{_baseTestName}7.txt");
            instance.FirstResult.Should().Be(-1);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}8.txt")]
        public void Part1_OutputsCorrectFloorFile8_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"{_baseTestName}8.txt");
            instance.FirstResult.Should().Be(-3);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}9.txt")]
        public void Part1_OutputsCorrectFloorFile9_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"{_baseTestName}9.txt");
            instance.FirstResult.Should().Be(-3);
        }


        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}5.txt")]
        public void Part2_OutputsCorrectPositionFile5_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"{_baseTestName}5.txt");
            instance.SecondResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}6.txt")]
        public void Part2_OutputsCorrectPositionFile6_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"{_baseTestName}6.txt");
            instance.SecondResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}7.txt")]
        public void Part2_OutputsCorrectPositionFile7_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"{_baseTestName}7.txt");
            instance.SecondResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}8.txt")]
        public void Part2_OutputsCorrectPositionFile8_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"{_baseTestName}8.txt");
            instance.SecondResult.Should().Be(1);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}9.txt")]
        public void Part2_OutputsCorrectPositionFile9_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"{_baseTestName}9.txt");
            instance.SecondResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}10.txt")]
        public void Part2_OutputsCorrectPositionFile10_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"{_baseTestName}10.txt");
            instance.SecondResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}11.txt")]
        public void Part2_OutputsCorrectPositionFile11_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"{_baseTestName}11.txt");
            instance.SecondResult.Should().Be(5);
        }
    }
}