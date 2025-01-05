namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day4
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day4/Day4Test1.txt")]
        public void Part1_FindsMinimumMD5HashKeyFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day4("Day4Test1.txt");
            instance.FirstResult.Should().Be(609043);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day4/Day4Test2.txt")]
        public void Part1_FindsMinimumMD5HashKeyFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day4("Day4Test2.txt");
            instance.FirstResult.Should().Be(1048970);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day4/Day4Test1.txt")]
        public void Part2_FindsMinimumMD5HashKeyFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day4("Day4Test1.txt");
            instance.SecondResult.Should().Be(6742839);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day4/Day4Test2.txt")]
        public void Part2_FindsMinimumMD5HashKeyFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day4("Day4Test2.txt");
            instance.SecondResult.Should().Be(5714438);
        }
    }
}