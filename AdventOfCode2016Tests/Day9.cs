namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day9
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day9/Day9Test1.txt")]
        public void Part1_OutputsCorrectStringLengthFile1_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day9("Day9Test1.txt");
            instance.FirstResult.ResultValue.Should().Be(6);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day9/Day9Test2.txt")]
        public void Part1_OutputsCorrectStringLengthFile2_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day9("Day9Test2.txt");
            instance.FirstResult.ResultValue.Should().Be(7);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day9/Day9Test3.txt")]
        public void Part1_OutputsCorrectStringLengthFile3_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day9("Day9Test3.txt");
            instance.FirstResult.ResultValue.Should().Be(9);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day9/Day9Test4.txt")]
        public void Part1_OutputsCorrectStringLengthFile4_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day9("Day9Test4.txt");
            instance.FirstResult.ResultValue.Should().Be(11);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day9/Day9Test5.txt")]
        public void Part1_OutputsCorrectStringLengthFile5_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day9("Day9Test5.txt");
            instance.FirstResult.ResultValue.Should().Be(6);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day9/Day9Test6.txt")]
        public void Part1_OutputsCorrectStringLengthFile6_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day9("Day9Test6.txt");
            instance.FirstResult.ResultValue.Should().Be(18);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day9/Day9Test3.txt")]
        public void Part2_OutputsCorrectStringLengthFile3_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day9("Day9Test3.txt");
            instance.SecondResult.ResultValue.Should().Be(9);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day9/Day9Test6.txt")]
        public void Part2_OutputsCorrectStringLengthFile6_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day9("Day9Test6.txt");
            instance.SecondResult.ResultValue.Should().Be(20);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day9/Day9Test7.txt")]
        public void Part2_OutputsCorrectStringLengthFile7_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day9("Day9Test7.txt");
            instance.SecondResult.ResultValue.Should().Be(241920);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day9/Day9Test8.txt")]
        public void Part2_OutputsCorrectStringLengthFile8_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day9("Day9Test8.txt");
            instance.SecondResult.ResultValue.Should().Be(445);
        }

        //27 + 18 + 30 = 
        // 75
    }
}