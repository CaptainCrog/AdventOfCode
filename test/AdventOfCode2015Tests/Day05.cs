namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day05
    {
        const string _basePath = "Inputs/Day05";
        const string _baseTestName = "Day5Test";

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_CorrectlyAssumesStringIsNaughtyFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day05($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_CorrectlyAssumesStringIsNiceFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day05($"{_baseTestName}2.txt");
            instance.FirstResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part1_CorrectlyAssumesStringIsNaughtyFile3_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day05($"{_baseTestName}3.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}4.txt")]
        public void Part1_CorrectlyAssumesStringIsNaughtyFile4_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day05($"{_baseTestName}4.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}5.txt")]
        public void Part1_CorrectlyAssumesStringIsNaughtyFile5_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day05($"{_baseTestName}5.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}6.txt")]
        public void Part1_CorrectlyAssumesStringIsNiceFile6_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day05($"{_baseTestName}6.txt");
            instance.FirstResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}7.txt")]
        public void Part1_CorrectlyAssumesStringIsNaughtyFile7_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day05($"{_baseTestName}7.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}8.txt")]
        public void Part1_CorrectlyAssumesStringIsNaughtyFile8_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day05($"{_baseTestName}8.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}9.txt")]
        public void Part1_CorrectlyAssumesStringIsNiceFile9_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day05($"{_baseTestName}9.txt");
            instance.FirstResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}10.txt")]
        public void Part1_CorrectlyAssumesStringIsNaughtyFile10_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day05($"{_baseTestName}10.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}11.txt")]
        public void Part1_CorrectlyAssumesStringIsNaughtyFile11_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day05($"{_baseTestName}11.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}12.txt")]
        public void Part1_CorrectlyAssumesStringIsNaughtyFile12_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day05($"{_baseTestName}12.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}13.txt")]
        public void Part1_CorrectlyAssumesStringIsNiceFile13_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day05($"{_baseTestName}13.txt");
            instance.FirstResult.Should().Be(1);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}14.txt")]
        public void Part2_CorrectlyAssumesStringIsNiceFile14_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day05($"{_baseTestName}14.txt");
            instance.SecondResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}15.txt")]
        public void Part2_CorrectlyAssumesStringIsNiceFile15_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day05($"{_baseTestName}15.txt");
            instance.SecondResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}16.txt")]
        public void Part2_CorrectlyAssumesStringIsNaughtyFile16_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day05($"{_baseTestName}16.txt");
            instance.SecondResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}17.txt")]
        public void Part2_CorrectlyAssumesStringIsNaughtyFile17_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day05($"{_baseTestName}17.txt");
            instance.SecondResult.Should().Be(0);
        }
    }
}