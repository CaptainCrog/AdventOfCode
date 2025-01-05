namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day5
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day5/Day5Test1.txt")]
        public void Part1_CorrectlyAssumesStringIsNaughtyFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day5("Day5Test1.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day5/Day5Test2.txt")]
        public void Part1_CorrectlyAssumesStringIsNiceFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day5("Day5Test2.txt");
            instance.FirstResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day5/Day5Test3.txt")]
        public void Part1_CorrectlyAssumesStringIsNaughtyFile3_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day5("Day5Test3.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day5/Day5Test4.txt")]
        public void Part1_CorrectlyAssumesStringIsNaughtyFile4_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day5("Day5Test4.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day5/Day5Test5.txt")]
        public void Part1_CorrectlyAssumesStringIsNaughtyFile5_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day5("Day5Test5.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day5/Day5Test6.txt")]
        public void Part1_CorrectlyAssumesStringIsNiceFile6_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day5("Day5Test6.txt");
            instance.FirstResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day5/Day5Test7.txt")]
        public void Part1_CorrectlyAssumesStringIsNaughtyFile7_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day5("Day5Test7.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day5/Day5Test8.txt")]
        public void Part1_CorrectlyAssumesStringIsNaughtyFile8_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day5("Day5Test8.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day5/Day5Test9.txt")]
        public void Part1_CorrectlyAssumesStringIsNiceFile9_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day5("Day5Test9.txt");
            instance.FirstResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day5/Day5Test10.txt")]
        public void Part1_CorrectlyAssumesStringIsNaughtyFile10_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day5("Day5Test10.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day5/Day5Test11.txt")]
        public void Part1_CorrectlyAssumesStringIsNaughtyFile11_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day5("Day5Test11.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day5/Day5Test12.txt")]
        public void Part1_CorrectlyAssumesStringIsNaughtyFile12_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day5("Day5Test12.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day5/Day5Test13.txt")]
        public void Part1_CorrectlyAssumesStringIsNiceFile13_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day5("Day5Test13.txt");
            instance.FirstResult.Should().Be(1);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day5/Day5Test14.txt")]
        public void Part2_CorrectlyAssumesStringIsNiceFile14_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day5("Day5Test14.txt");
            instance.SecondResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day5/Day5Test15.txt")]
        public void Part2_CorrectlyAssumesStringIsNiceFile15_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day5("Day5Test15.txt");
            instance.SecondResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day5/Day5Test16.txt")]
        public void Part2_CorrectlyAssumesStringIsNaughtyFile16_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day5("Day5Test16.txt");
            instance.SecondResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day5/Day5Test17.txt")]
        public void Part2_CorrectlyAssumesStringIsNaughtyFile17_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day5("Day5Test17.txt");
            instance.SecondResult.Should().Be(0);
        }
    }
}