namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day04
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day04/Day4Test1.txt")]
        public void Part1_OutputsIsValidFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day04("Day4Test1.txt");
            instance.FirstResult.Should().Be(1);
        }


        [TestMethod]
        [DeploymentItem("Inputs/Day04/Day4Test2.txt")]
        public void Part1_OutputsIsValidFile2_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day04("Day4Test2.txt");
            instance.FirstResult.Should().Be(0);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day04/Day4Test3.txt")]
        public void Part1_OutputsIsValidFile3_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day04("Day4Test3.txt");
            instance.FirstResult.Should().Be(1);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day04/Day4Test4.txt")]
        public void Part2_OutputsIsValidFile4_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day04("Day4Test4.txt");
            instance.SecondResult.Should().Be(1);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day04/Day4Test5.txt")]
        public void Part2_OutputsIsValidFile5_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day04("Day4Test5.txt");
            instance.SecondResult.Should().Be(0);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day04/Day4Test6.txt")]
        public void Part2_OutputsIsValidFile6_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day04("Day4Test6.txt");
            instance.SecondResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day04/Day4Test7.txt")]
        public void Part2_OutputsIsValidFile7_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day04("Day4Test7.txt");
            instance.SecondResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day04/Day4Test8.txt")]
        public void Part2_OutputsIsValidFile8_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day04("Day4Test8.txt");
            instance.SecondResult.Should().Be(0);
        }
    }
}