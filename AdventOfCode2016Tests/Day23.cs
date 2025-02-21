namespace AdventOfCode2016Tests
{
    [TestClass]
    public class Day23
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day23/Day23Test1.txt")]
        public void Part1_OutputsCorrectValueAtRegisterA_IsTrue()
        {
            var instance = new AdventOfCode2016.Problems.Day23("Day23Test1.txt", 0);
            instance.FirstResult.Should().Be(3);
        }
    }
}