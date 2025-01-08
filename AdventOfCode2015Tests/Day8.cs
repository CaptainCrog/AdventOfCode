namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day8
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day8/Day8Test1.txt")]
        public void Part1_ProducesCorrectResultFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day8("Day8Test1.txt");
            instance.FirstResult.Should().Be(2);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day8/Day8Test2.txt")]
        public void Part1_ProducesCorrectResultFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day8("Day8Test2.txt");
            instance.FirstResult.Should().Be(2);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day8/Day8Test3.txt")]
        public void Part1_ProducesCorrectResultFile3_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day8("Day8Test3.txt");
            instance.FirstResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day8/Day8Test4.txt")]
        public void Part1_ProducesCorrectResultFile4_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day8("Day8Test4.txt");
            instance.FirstResult.Should().Be(5);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day8/Day8Test5.txt")]
        public void Part1_ProducesCorrectResultFile5_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day8("Day8Test5.txt");
            instance.FirstResult.Should().Be(12);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day8/Day8Test6.txt")]
        public void Part1_ProducesCorrectResultFile6_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day8("Day8Test6.txt");
            instance.FirstResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day8/Day8Test7.txt")]
        public void Part1_ProducesCorrectResultFile7_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day8("Day8Test7.txt");
            instance.FirstResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day8/Day8Test8.txt")]
        public void Part1_ProducesCorrectResultFile8_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day8("Day8Test8.txt");
            instance.FirstResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day8/Day8Test9.txt")]
        public void Part1_ProducesCorrectResultFile9_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day8("Day8Test9.txt");
            instance.FirstResult.Should().Be(5);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day8/Day8Test10.txt")]
        public void Part1_ProducesCorrectResultFile10_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day8("Day8Test10.txt");
            instance.FirstResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day8/Day8Test11.txt")]
        public void Part1_ProducesCorrectResultFile11_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day8("Day8Test11.txt");
            instance.FirstResult.Should().Be(6);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day8/Day8Test12.txt")]
        public void Part1_ProducesCorrectResultFile12_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day8("Day8Test12.txt");
            instance.FirstResult.Should().Be(4);
        }

        //[TestMethod]
        //[DeploymentItem("Inputs/Day8/Day8Test1.txt")]
        //public void Part2_ProducesCorrectTotalOfUniqueAntinodesFile1_IsTrue()
        //{
        //    var instance = new AdventOfCode2015.Problems.Day8("Day8Test1.txt");
        //    instance.SecondResult.Should().Be(34);
        //}

        //[TestMethod]
        //[DeploymentItem("Inputs/Day8/Day8Test4.txt")]
        //public void Part2_ProducesCorrectTotalOfUniqueAntinodesFile4_IsTrue()
        //{
        //    var instance = new AdventOfCode2015.Problems.Day8("Day8Test4.txt");
        //    instance.SecondResult.Should().Be(9);
        //}
    }
}