namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day08
    {
        const string _basePath = "Inputs/Day08";
        const string _baseTestName = "Day8Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectTrueCount_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day08($"{_baseTestName}1.txt", 3, 7);
            instance.FirstResult.Should().Be(6);
        }

        //No part 2 data to test against
    }
}