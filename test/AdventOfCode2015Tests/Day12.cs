namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day12
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day12/Day12Test1.txt")]
        public void Part1_CalculatesCorrectValueFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12("Day12Test1.txt");
            instance.FirstResult.Should().Be(6);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day12/Day12Test2.txt")]
        public void Part1_CalculatesCorrectValueFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12("Day12Test2.txt");
            instance.FirstResult.Should().Be(6);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day12/Day12Test3.txt")]
        public void Part1_CalculatesCorrectValueFile3_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12("Day12Test3.txt");
            instance.FirstResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day12/Day12Test4.txt")]
        public void Part1_CalculatesCorrectValueFile4_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12("Day12Test4.txt");
            instance.FirstResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day12/Day12Test5.txt")]
        public void Part1_CalculatesCorrectValueFile5_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12("Day12Test5.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day12/Day12Test6.txt")]
        public void Part1_CalculatesCorrectValueFile6_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12("Day12Test6.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day12/Day12Test7.txt")]
        public void Part1_CalculatesCorrectValueFile7_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12("Day12Test7.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day12/Day12Test8.txt")]
        public void Part1_CalculatesCorrectValueFile8_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12("Day12Test8.txt");
            instance.FirstResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day12/Day12Test9.txt")]
        public void Part1_CalculatesCorrectValueFile9_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12("Day12Test9.txt");
            instance.FirstResult.Should().Be(171);
        }



        [TestMethod]
        [DeploymentItem("Inputs/Day12/Day12Test1.txt")]
        public void Part2_CalculatesCorrectValueFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12("Day12Test1.txt");
            instance.SecondResult.Should().Be(6);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day12/Day12Test10.txt")]
        public void Part2_CalculatesCorrectBulkDiscountPriceFile10_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12("Day12Test10.txt");
            instance.SecondResult.Should().Be(4);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day12/Day12Test11.txt")]
        public void Part2_CalculatesCorrectBulkDiscountPriceFile11_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12("Day12Test11.txt");
            instance.SecondResult.Should().Be(0);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day12/Day12Test12.txt")]
        public void Part2_CalculatesCorrectBulkDiscountPriceFile12_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day12("Day12Test12.txt");
            instance.SecondResult.Should().Be(6);
        }
    }
}