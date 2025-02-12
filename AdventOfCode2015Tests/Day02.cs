namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day02
    {
        const string _prefix = "Inputs/Day02/";

        [TestMethod]
        [DeploymentItem($"{_prefix}Day2Test1.txt")]
        public void Part1_CalculatesSquareFeetCorrectlyFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day02("Day2Test1.txt");
            instance.FirstResult.Should().Be(58);
        }
        [TestMethod]
        [DeploymentItem($"{_prefix}Day2Test2.txt")]
        public void Part1_CalculatesSquareFeetCorrectlyFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day02("Day2Test2.txt");
            instance.FirstResult.Should().Be(43);
        }
        [TestMethod]
        [DeploymentItem($"{_prefix}Day2Test3.txt")]
        public void Part1_CalculatesSquareFeetCorrectlyFile3_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day02("Day2Test3.txt");
            instance.FirstResult.Should().Be(101);
        }

        [TestMethod]
        [DeploymentItem($"{_prefix}Day2Test1.txt")]
        public void Part2_CalculatesRibbonFeetCorrectlyFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day02("Day2Test1.txt");
            instance.SecondResult.Should().Be(34);
        }
        [TestMethod]
        [DeploymentItem($"{_prefix}Day2Test2.txt")]
        public void Part2_CalculatesRibbonFeetCorrectlyFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day02("Day2Test2.txt");
            instance.SecondResult.Should().Be(14);
        }
        [TestMethod]
        [DeploymentItem($"{_prefix}Day2Test3.txt")]
        public void Part2_CalculatesRibbonFeetCorrectlyFile3_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day02("Day2Test3.txt");
            instance.SecondResult.Should().Be(48);
        }
        [TestMethod]
        [DeploymentItem($"{_prefix}Day2Test4.txt")]
        public void Part2_CalculatesRibbonFeetCorrectlyFile4_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day02("Day2Test4.txt");
            instance.SecondResult.Should().Be(62);
        }
    }
}