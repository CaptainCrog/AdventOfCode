namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day8
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day8/Day8Test1.txt")]
        public void Part1_ProducesCorrectTotalOfUniqueAntinodesFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day8("Day8Test1.txt");
            instance.FirstResult.Should().Be(14);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day8/Day8Test2.txt")]
        public void Part1_ProducesCorrectTotalOfUniqueAntinodesFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day8("Day8Test2.txt");
            instance.FirstResult.Should().Be(2);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day8/Day8Test3.txt")]
        public void Part1_ProducesCorrectTotalOfUniqueAntinodesFile3_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day8("Day8Test3.txt");
            instance.FirstResult.Should().Be(4);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day8/Day8Test1.txt")]
        public void Part2_ProducesCorrectTotalOfUniqueAntinodesFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day8("Day8Test1.txt");
            instance.SecondResult.Should().Be(34);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day8/Day8Test4.txt")]
        public void Part2_ProducesCorrectTotalOfUniqueAntinodesFile4_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day8("Day8Test4.txt");
            instance.SecondResult.Should().Be(9);
        }
    }
}