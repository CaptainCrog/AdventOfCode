namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day03
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day03/Day3Test1.txt")]
        public void Part1_OutputsCorrectDistanceFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day03("Day3Test1.txt");
            instance.FirstResult.Should().Be(0);
        }


        [TestMethod]
        [DeploymentItem("Inputs/Day03/Day3Test2.txt")]
        public void Part1_OutputsCorrectDistanceFile2_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day03("Day3Test2.txt");
            instance.FirstResult.Should().Be(3);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day03/Day3Test3.txt")]
        public void Part1_OutputsCorrectDistanceFile3_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day03("Day3Test3.txt");
            instance.FirstResult.Should().Be(2);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day03/Day3Test4.txt")]
        public void Part1_OutputsCorrectDistanceFile4_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day03("Day3Test4.txt");
            instance.FirstResult.Should().Be(31);
        }
    }
}