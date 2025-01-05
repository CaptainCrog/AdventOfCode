namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day15
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day15/Day15Test1.txt")]
        public void Part1_ProducesCorrectSumOfBoxCoordinatesFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day15("Day15Test1.txt");
            instance.FirstResult.Should().Be(2028);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day15/Day15Test2.txt")]
        public void Part1_ProducesCorrectSumOfBoxCoordinatesFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day15("Day15Test2.txt");
            instance.FirstResult.Should().Be(10092);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day15/Day15Test3.txt")]
        public void Part2_ProducesCorrectSumOfBoxCoordinatesFile3_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day15("Day15Test3.txt");
            instance.SecondResult.Should().Be(618);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day15/Day15Test2.txt")]
        public void Part2_ProducesCorrectSumOfBoxCoordinatesFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day15("Day15Test2.txt");
            instance.SecondResult.Should().Be(9021);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day15/Day15Test4.txt")]
        public void Part2_ProducesCorrectSumOfBoxCoordinatesFile4_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day15("Day15Test4.txt");
            instance.SecondResult.Should().Be(406);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day15/Day15Test5.txt")]
        public void Part2_ProducesCorrectSumOfBoxCoordinatesFile5_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day15("Day15Test5.txt");
            instance.SecondResult.Should().Be(509);
        }
    }
}