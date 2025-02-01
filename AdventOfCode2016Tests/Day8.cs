namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day8
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day8/Day8Test1.txt")]
        public void Part1_OutputsValidIpAddressCountFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day8("Day8Test1.txt", 3, 7);
            instance.FirstResult.ResultValue.Should().Be(6);
        }

        //[TestMethod]
        //[DeploymentItem("Inputs/Day8/Day8Test5.txt")]
        //public void Part2_OutputsSslSupportedIpAddressesFile5_IsTrue()
        //{
        //    var instance = new AdventOfCode2016.Problems.Day8("Day8Test5.txt");
        //    instance.SecondResult.ResultValue.Should().Be(1);
        //}
    }
}