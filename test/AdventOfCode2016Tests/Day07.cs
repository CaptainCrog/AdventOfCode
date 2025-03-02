namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day07
    {
        const string _basePath = "Inputs/Day07";
        const string _baseTestName = "Day7Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsValidIpAddressCountFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day07($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_OutputsValidIpAddressCountFile2_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day07($"{_baseTestName}2.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part1_OutputsValidIpAddressCountFile3_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day07($"{_baseTestName}3.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}4.txt")]
        public void Part1_OutputsValidIpAddressCountFile4_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day07($"{_baseTestName}4.txt");
            instance.FirstResult.Should().Be(1);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}5.txt")]
        public void Part2_OutputsSslSupportedIpAddressesFile5_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day07($"{_baseTestName}5.txt");
            instance.SecondResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}6.txt")]
        public void Part2_OutputsSslSupportedIpAddressesFile6_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day07($"{_baseTestName}6.txt");
            instance.SecondResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}7.txt")]
        public void Part2_OutputsSslSupportedIpAddressesFile7_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day07($"{_baseTestName}7.txt");
            instance.SecondResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}8.txt")]
        public void Part2_OutputsSslSupportedIpAddressesFile8_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day07($"{_baseTestName}8.txt");
            instance.SecondResult.Should().Be(1);
        }
    }
}