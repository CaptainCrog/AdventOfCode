namespace AdventOfCode2018Tests
{
    [TestClass]
    public class Day01
    {
        const string _basePath = "Inputs/Day01";
        const string _baseTestName = "Day1Test";

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectFrequencyCalibrationFile1_IsTrue()
        {
            var instance = new AdventOfCode2018.Problems.Day01($"{_baseTestName}1.txt", 1);
            instance.FirstResult.Should().Be(3);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_OutputsCorrectFrequencyCalibrationFile2_IsTrue()
        {
            var instance = new AdventOfCode2018.Problems.Day01($"{_baseTestName}2.txt", 1);
            instance.FirstResult.Should().Be(3);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part1_OutputsCorrectFrequencyCalibrationFile3_IsTrue()
        {
            var instance = new AdventOfCode2018.Problems.Day01($"{_baseTestName}3.txt", 1);
            instance.FirstResult.Should().Be(0);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}4.txt")]
        public void Part1_OutputsCorrectFrequencyCalibrationFile4_IsTrue()
        {
            var instance = new AdventOfCode2018.Problems.Day01($"{_baseTestName}4.txt", 1);
            instance.FirstResult.Should().Be(-6);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}5.txt")]
        public void Part2_OutputsCorrectFrequencyCalibrationFile5_IsTrue()
        {
            var instance = new AdventOfCode2018.Problems.Day01($"{_baseTestName}5.txt");
            instance.SecondResult.Should().Be(0);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}6.txt")]
        public void Part2_OutputsCorrectFrequencyCalibrationFile6_IsTrue()
        {
            var instance = new AdventOfCode2018.Problems.Day01($"{_baseTestName}6.txt");
            instance.SecondResult.Should().Be(10);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}7.txt")]
        public void Part2_OutputsCorrectFrequencyCalibrationFile7_IsTrue()
        {
            var instance = new AdventOfCode2018.Problems.Day01($"{_baseTestName}7.txt");
            instance.SecondResult.Should().Be(5);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}8.txt")]
        public void Part2_OutputsCorrectFrequencyCalibrationFile8_IsTrue()
        {
            var instance = new AdventOfCode2018.Problems.Day01($"{_baseTestName}8.txt");
            instance.SecondResult.Should().Be(14);
        }
    }
}