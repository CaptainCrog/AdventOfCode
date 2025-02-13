namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day07
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day07/Day7Test1.txt")]
        public void Part1_OutputsValidIpAddressCountFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day07("Day7Test1.txt");
            instance.FirstResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day07/Day7Test2.txt")]
        public void Part1_OutputsValidIpAddressCountFile2_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day07("Day7Test2.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day07/Day7Test3.txt")]
        public void Part1_OutputsValidIpAddressCountFile3_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day07("Day7Test3.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day07/Day7Test4.txt")]
        public void Part1_OutputsValidIpAddressCountFile4_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day07("Day7Test4.txt");
            instance.FirstResult.Should().Be(1);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day07/Day7Test5.txt")]
        public void Part2_OutputsSslSupportedIpAddressesFile5_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day07("Day7Test5.txt");
            instance.SecondResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day07/Day7Test6.txt")]
        public void Part2_OutputsSslSupportedIpAddressesFile6_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day07("Day7Test6.txt");
            instance.SecondResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day07/Day7Test7.txt")]
        public void Part2_OutputsSslSupportedIpAddressesFile7_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day07("Day7Test7.txt");
            instance.SecondResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day07/Day7Test8.txt")]
        public void Part2_OutputsSslSupportedIpAddressesFile8_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day07("Day7Test8.txt");
            instance.SecondResult.Should().Be(1);
        }
    }
}