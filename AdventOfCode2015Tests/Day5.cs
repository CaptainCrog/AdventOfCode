namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day5
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day5/Day5Test1.txt")]
        public void Part1_ProducesCorrectTotalOfAlreadyOrderedMiddlePageNumbers_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day5("Day5Test1.txt");
            instance.FirstResult.Should().Be(143);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day5/Day5Test1.txt")]
        public void Part2_ProducesCorrectTotalOfIncorrectlyOrderedMiddlePageNumbersAfterModification_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day5("Day5Test1.txt");
            instance.SecondResult.Should().Be(123);
        }
    }
}