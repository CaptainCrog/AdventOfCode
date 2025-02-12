namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day01
    {
        const string _prefix = "Inputs/Day01/";

        [TestMethod]
        [DeploymentItem($"{_prefix}Day1Test1.txt")]
        public void Part1_OutputsCorrectFloorFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"Day1Test1.txt");
            instance.FirstResult.Should().Be(0);
        }

        [TestMethod]
        [DeploymentItem($"{_prefix}Day1Test2.txt")]
        public void Part1_OutputsCorrectFloorFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"Day1Test2.txt");
            instance.FirstResult.Should().Be(0);
        }

        [TestMethod]
        [DeploymentItem($"{_prefix}Day1Test3.txt")]
        public void Part1_OutputsCorrectFloorFile3_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"Day1Test3.txt");
            instance.FirstResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem($"{_prefix}Day1Test4.txt")]
        public void Part1_OutputsCorrectFloorFile4_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"Day1Test4.txt");
            instance.FirstResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem($"{_prefix}Day1Test5.txt")]
        public void Part1_OutputsCorrectFloorFile5_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"Day1Test5.txt");
            instance.FirstResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem($"{_prefix}Day1Test6.txt")]
        public void Part1_OutputsCorrectFloorFile6_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"Day1Test6.txt");
            instance.FirstResult.Should().Be(-1);
        }
        [TestMethod]
        [DeploymentItem($"{_prefix}Day1Test7.txt")]
        public void Part1_OutputsCorrectFloorFile7_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"Day1Test7.txt");
            instance.FirstResult.Should().Be(-1);
        }
        [TestMethod]
        [DeploymentItem($"{_prefix}Day1Test8.txt")]
        public void Part1_OutputsCorrectFloorFile8_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"Day1Test8.txt");
            instance.FirstResult.Should().Be(-3);
        }

        [TestMethod]
        [DeploymentItem($"{_prefix}Day1Test9.txt")]
        public void Part1_OutputsCorrectFloorFile9_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"Day1Test9.txt");
            instance.FirstResult.Should().Be(-3);
        }


        [TestMethod]
        [DeploymentItem($"{_prefix}Day1Test5.txt")]
        public void Part2_OutputsCorrectPositionFile5_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"Day1Test5.txt");
            instance.SecondResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem($"{_prefix}Day1Test6.txt")]
        public void Part2_OutputsCorrectPositionFile6_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"Day1Test6.txt");
            instance.SecondResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem($"{_prefix}Day1Test7.txt")]
        public void Part2_OutputsCorrectPositionFile7_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"Day1Test7.txt");
            instance.SecondResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem($"{_prefix}Day1Test8.txt")]
        public void Part2_OutputsCorrectPositionFile8_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"Day1Test8.txt");
            instance.SecondResult.Should().Be(1);
        }

        [TestMethod]
        [DeploymentItem($"{_prefix}Day1Test9.txt")]
        public void Part2_OutputsCorrectPositionFile9_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"Day1Test9.txt");
            instance.SecondResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem($"{_prefix}Day1Test10.txt")]
        public void Part2_OutputsCorrectPositionFile10_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"Day1Test10.txt");
            instance.SecondResult.Should().Be(1);
        }
        [TestMethod]
        [DeploymentItem($"{_prefix}Day1Test11.txt")]
        public void Part2_OutputsCorrectPositionFile11_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day01($"Day1Test11.txt");
            instance.SecondResult.Should().Be(5);
        }
    }
}