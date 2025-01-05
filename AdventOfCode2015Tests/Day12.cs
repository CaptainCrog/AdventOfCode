namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day12
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day12/Day12Test1.txt")]
        public void Part1_CalculatesCorrectAreaFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12("Day12Test1.txt");
            instance.FirstResult.Should().Be(140);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day12/Day12Test2.txt")]
        public void Part1_CalculatesCorrectAreaFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12("Day12Test2.txt");
            instance.FirstResult.Should().Be(772);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day12/Day12Test3.txt")]
        public void Part1_CalculatesCorrectAreaFile3_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12("Day12Test3.txt");
            instance.FirstResult.Should().Be(1930);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day12/Day12Test1.txt")]
        public void Part2_CalculatesCorrectBulkDiscountPriceFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12("Day12Test1.txt");
            instance.SecondResult.Should().Be(80);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day12/Day12Test2.txt")]
        public void Part2_CalculatesCorrectBulkDiscountPriceFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12("Day12Test2.txt");
            instance.SecondResult.Should().Be(436);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day12/Day12Test4.txt")]
        public void Part2_CalculatesCorrectBulkDiscountPriceFile4_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12("Day12Test4.txt");
            instance.SecondResult.Should().Be(236);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day12/Day12Test5.txt")]
        public void Part2_CalculatesCorrectBulkDiscountPriceFile5_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12("Day12Test5.txt");
            instance.SecondResult.Should().Be(368);
        }
    }
}