namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day01
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day01/Day1Test1.txt")]
        public void Part1_OutputsCorrectSumFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day01("Day1Test1.txt");
            instance.FirstResult.Should().Be(3);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day01/Day1Test2.txt")]
        public void Part1_OutputsCorrectSumFile2_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day01("Day1Test2.txt");
            instance.FirstResult.Should().Be(4);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day01/Day1Test3.txt")]
        public void Part1_OutputsCorrectSumFile3_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day01("Day1Test3.txt");
            instance.FirstResult.Should().Be(0);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day01/Day1Test4.txt")]
        public void Part1_OutputsCorrectSumFile4_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day01("Day1Test4.txt");
            instance.FirstResult.Should().Be(9);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day01/Day1Test5.txt")]
        public void Part2_OutputsCorrectSumFile5_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day01("Day1Test5.txt");
            instance.SecondResult.Should().Be(6);
        }


        [TestMethod]
        [DeploymentItem("Inputs/Day01/Day1Test6.txt")]
        public void Part2_OutputsCorrectSumFile6_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day01("Day1Test6.txt");
            instance.SecondResult.Should().Be(0);
        }


        [TestMethod]
        [DeploymentItem("Inputs/Day01/Day1Test7.txt")]
        public void Part2_OutputsCorrectSumFile7_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day01("Day1Test7.txt");
            instance.SecondResult.Should().Be(4);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day01/Day1Test8.txt")]
        public void Part2_OutputsCorrectSumFile8_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day01("Day1Test8.txt");
            instance.SecondResult.Should().Be(12);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day01/Day1Test9.txt")]
        public void Part2_OutputsCorrectSumFile9_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day01("Day1Test9.txt");
            instance.SecondResult.Should().Be(4);
        }
    }
}