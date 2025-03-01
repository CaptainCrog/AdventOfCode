namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day04
    {
        const string _basePath = "Inputs/Day04";
        const string _baseTestName = "Day4Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsIsValidFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day04($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(1);
        }


        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_OutputsIsValidFile2_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day04($"{_baseTestName}2.txt");
            instance.FirstResult.Should().Be(0);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part1_OutputsIsValidFile3_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day04($"{_baseTestName}3.txt");
            instance.FirstResult.Should().Be(1);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}4.txt")]
        public void Part2_OutputsIsValidFile4_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day04($"{_baseTestName}4.txt");
            instance.SecondResult.Should().Be(1);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}5.txt")]
        public void Part2_OutputsIsValidFile5_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day04($"{_baseTestName}5.txt");
            instance.SecondResult.Should().Be(0);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}6.txt")]
        public void Part2_OutputsIsValidFile6_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day04($"{_baseTestName}6.txt");
            instance.SecondResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}7.txt")]
        public void Part2_OutputsIsValidFile7_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day04($"{_baseTestName}7.txt");
            instance.SecondResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}8.txt")]
        public void Part2_OutputsIsValidFile8_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day04($"{_baseTestName}8.txt");
            instance.SecondResult.Should().Be(0);
        }
    }
}