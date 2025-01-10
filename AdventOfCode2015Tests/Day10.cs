namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day10
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day10/Day10Test1.txt")]
        public void Part1_ProducesCorrectValueOutput_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day10("Day10Test1.txt", 1);
            instance.FirstResult.Should().Be(2);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day10/Day10Test2.txt")]
        public void Part1_ProducesCorrectTrailHeadCountFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day10("Day10Test2.txt", 1);
            instance.FirstResult.Should().Be(2);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day10/Day10Test3.txt")]
        public void Part1_ProducesCorrectTrailHeadCountFile3_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day10("Day10Test3.txt", 1);
            instance.FirstResult.Should().Be(4);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day10/Day10Test4.txt")]
        public void Part1_ProducesCorrectTrailHeadCountFile4_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day10("Day10Test4.txt", 1);
            instance.FirstResult.Should().Be(6);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day10/Day10Test5.txt")]
        public void Part1_ProducesCorrectTrailHeadCountFile5_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day10("Day10Test5.txt", 1);
            instance.FirstResult.Should().Be(7);
        }
        // No part 2 tests as it builds off the original functionality again which is already covered by part 1 tests
    }
}