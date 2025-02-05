namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day12
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day12/Day12Test1.txt")]
        public void Part1_OutputsCorrectRegisterOutput_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day12("Day12Test1.txt");
            instance.FirstResult.ResultValue.Should().Be(42);
        }
    }
}