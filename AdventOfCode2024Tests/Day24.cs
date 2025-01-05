namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day24
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day24/Day24Test1.txt")]
        public void Part1_ProducesCorrectBinaryZValueFile1_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day24("Day24Test1.txt", "z06");
            instance.FirstResult.Should().Be(4);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day24/Day24Test2.txt")]
        public void Part1_ProducesCorrectBinaryZValueFile2_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day24("Day24Test2.txt", "z06");
            instance.FirstResult.Should().Be(2024);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day24/Day24Test3.txt")]
        public void Part2_ProducesCorrectWiresToSwap_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day24("Day24Test3.txt", "z06");
            instance.SecondResult.Should().Be("z00,z01,z02,z05");
        }
    }
}