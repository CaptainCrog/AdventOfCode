namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Day03
    {
        const string _basePath = "Inputs/Day03";
        const string _baseTestName = "Day3Test";

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_OutputsCorrectDistanceFile1_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day03($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(0);
        }


        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_OutputsCorrectDistanceFile2_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day03($"{_baseTestName}2.txt");
            instance.FirstResult.Should().Be(3);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part1_OutputsCorrectDistanceFile3_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day03($"{_baseTestName}3.txt");
            instance.FirstResult.Should().Be(2);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}4.txt")]
        public void Part1_OutputsCorrectDistanceFile4_IsTrue()
        {
            var instance = new AdventOfCode2017.Problems.Day03($"{_baseTestName}4.txt");
            instance.FirstResult.Should().Be(31);
        }
    }
}