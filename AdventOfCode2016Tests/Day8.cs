namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day8
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day8/Day8Test1.txt")]
        public void Part1_OutputsCorrectTrueCount_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day8("Day8Test1.txt", 3, 7);
            instance.FirstResult.Should().Be(6);
        }

        //No part 2 data to test against
    }
}