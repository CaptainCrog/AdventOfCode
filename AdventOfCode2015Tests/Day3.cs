namespace AdventOfCode2015Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day3/Day3Test1.txt")]
        public void Part1_CalculatesDistinctHousePositionsFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day3("Day3Test1.txt");
            instance.FirstResult.Should().Be(2);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day3/Day3Test2.txt")]
        public void Part1_CalculatesDistinctHousePositionsFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day3("Day3Test2.txt");
            instance.FirstResult.Should().Be(4);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day3/Day3Test3.txt")]
        public void Part1_CalculatesDistinctHousePositionsFile3_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day3("Day3Test3.txt");
            instance.FirstResult.Should().Be(2);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day3/Day3Test4.txt")]
        public void Part2_CalculatesDistinctHousePositionsFile4_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day3("Day3Test4.txt");
            instance.SecondResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day3/Day3Test2.txt")]
        public void Part2_CalculatesDistinctHousePositionsFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day3("Day3Test2.txt");
            instance.SecondResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem("Inputs/Day3/Day3Test3.txt")]
        public void Part2_CalculatesDistinctHousePositionsFile3_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day3("Day3Test3.txt");
            instance.SecondResult.Should().Be(11);
        }
    }
}