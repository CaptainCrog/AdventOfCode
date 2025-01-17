namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day19
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day19/Day19Test1.txt")]
        public void Part1_ProducesCorrectNumberOfDistinctCalibrationsFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day19("Day19Test1.txt");
            instance.FirstResult.Should().Be(4);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day19/Day19Test2.txt")]
        public void Part1_ProducesCorrectNumberOfDistinctCalibrationsFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day19("Day19Test2.txt");
            instance.FirstResult.Should().Be(7);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day19/Day19Test1.txt")]
        public void Part2_ProducesCorrectNumberOfStepsToGetToMedicineMoleculeFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day19("Day19Test1.txt");
            instance.SecondResult.Should().Be(3);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day19/Day19Test2.txt")]
        public void Part2_ProducesCorrectNumberOfStepsToGetToMedicineMoleculeFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day19("Day19Test2.txt");
            instance.SecondResult.Should().Be(6);
        }
    }
}