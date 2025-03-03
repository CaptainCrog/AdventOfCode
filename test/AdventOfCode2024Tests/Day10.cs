namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day10
    {
        const string _basePath = "Inputs/Day10";
        const string _baseTestName = "Day10Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesCorrectTrailHeadCountFile1_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day10("Day10Test1.txt");
            instance.FirstResult.Should().Be(1);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_ProducesCorrectTrailHeadCountFile2_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day10("Day10Test2.txt");
            instance.FirstResult.Should().Be(2);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part1_ProducesCorrectTrailHeadCountFile3_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day10("Day10Test3.txt");
            instance.FirstResult.Should().Be(4);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}4.txt")]
        public void Part1_ProducesCorrectTrailHeadCountFile4_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day10("Day10Test4.txt");
            instance.FirstResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}5.txt")]
        public void Part1_ProducesCorrectTrailHeadCountFile5_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day10("Day10Test5.txt");
            instance.FirstResult.Should().Be(36);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}6.txt")]
        public void Part2_ProducesCorrectTrailHeadRatingFile6_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day10("Day10Test6.txt");
            instance.SecondResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part2_ProducesCorrectTrailHeadRatingFile3_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day10("Day10Test3.txt");
            instance.SecondResult.Should().Be(13);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}7.txt")]
        public void Part2_ProducesCorrectTrailHeadRatingFile7_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day10("Day10Test7.txt");
            instance.SecondResult.Should().Be(227);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}5.txt")]
        public void Part2_ProducesCorrectTrailHeadRatingFile5_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day10("Day10Test5.txt");
            instance.SecondResult.Should().Be(81);
        }
    }
}