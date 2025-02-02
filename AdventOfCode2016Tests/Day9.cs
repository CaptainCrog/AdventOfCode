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

        //No part 2 data to test against
    }
}