namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day07
    {
        const string _basePath = "Inputs/Day07";
        const string _baseTestName = "Day7Test";
        //No day 7 Part 2 tests as it builds off the same logic covered in Part 1's tests
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_FindsDValue_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day07($"{_baseTestName}1.txt", "d");
            instance.FirstResult.Should().Be(72);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_FindsEValue_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day07($"{_baseTestName}1.txt", "e");
            instance.FirstResult.Should().Be(507);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_FindsFValue_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day07($"{_baseTestName}1.txt", "f");
            instance.FirstResult.Should().Be(492);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_FindsGValue_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day07($"{_baseTestName}1.txt", "g");
            instance.FirstResult.Should().Be(114);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_FindsHValue_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day07($"{_baseTestName}1.txt", "h");
            instance.FirstResult.Should().Be(65412);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_FindsIValue_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day07($"{_baseTestName}1.txt", "i");
            instance.FirstResult.Should().Be(65079);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_FindsXValue_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day07($"{_baseTestName}1.txt", "x");
            instance.FirstResult.Should().Be(123);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_FindsYValue_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day07($"{_baseTestName}1.txt", "y");
            instance.FirstResult.Should().Be(456);
        }
    }
}