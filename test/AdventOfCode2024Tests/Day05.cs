namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day05
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day05/Day5Test1.txt")]
        public void Part1_ProducesCorrectTotalOfAlreadyOrderedMiddlePageNumbers_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day05("Day5Test1.txt");
            instance.FirstResult.Should().Be(143);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day05/Day5Test1.txt")]
        public void Part2_ProducesCorrectTotalOfIncorrectlyOrderedMiddlePageNumbersAfterModification_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day05("Day5Test1.txt");
            instance.SecondResult.Should().Be(123);
        }
    }
}