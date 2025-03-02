namespace AdventOfCode2015Tests
{
    [TestClass]
    public class Day08
    {
        const string _basePath = "Inputs/Day08";
        const string _baseTestName = "Day8Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesCorrectResultFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day08($"{_baseTestName}1.txt");
            instance.FirstResult.Should().Be(2);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part1_ProducesCorrectResultFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day08($"{_baseTestName}2.txt");
            instance.FirstResult.Should().Be(2);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part1_ProducesCorrectResultFile3_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day08($"{_baseTestName}3.txt");
            instance.FirstResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}4.txt")]
        public void Part1_ProducesCorrectResultFile4_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day08($"{_baseTestName}4.txt");
            instance.FirstResult.Should().Be(5);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}5.txt")]
        public void Part1_ProducesCorrectResultFile5_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day08($"{_baseTestName}5.txt");
            instance.FirstResult.Should().Be(12);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}6.txt")]
        public void Part1_ProducesCorrectResultFile6_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day08($"{_baseTestName}6.txt");
            instance.FirstResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}7.txt")]
        public void Part1_ProducesCorrectResultFile7_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day08($"{_baseTestName}7.txt");
            instance.FirstResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}8.txt")]
        public void Part1_ProducesCorrectResultFile8_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day08($"{_baseTestName}8.txt");
            instance.FirstResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}9.txt")]
        public void Part1_ProducesCorrectResultFile9_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day08($"{_baseTestName}9.txt");
            instance.FirstResult.Should().Be(5);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}10.txt")]
        public void Part1_ProducesCorrectResultFile10_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day08($"{_baseTestName}10.txt");
            instance.FirstResult.Should().Be(3);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}11.txt")]
        public void Part1_ProducesCorrectResultFile11_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day08($"{_baseTestName}11.txt");
            instance.FirstResult.Should().Be(6);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}12.txt")]
        public void Part1_ProducesCorrectResultFile12_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day08($"{_baseTestName}12.txt");
            instance.FirstResult.Should().Be(4);
        }


        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part2_ProducesCorrectResultFile1_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day08($"{_baseTestName}1.txt");
            instance.SecondResult.Should().Be(4);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}2.txt")]
        public void Part2_ProducesCorrectResultFile2_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day08($"{_baseTestName}2.txt");
            instance.SecondResult.Should().Be(4);
        }

        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}3.txt")]
        public void Part2_ProducesCorrectResultFile3_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day08($"{_baseTestName}3.txt");
            instance.SecondResult.Should().Be(6);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}4.txt")]
        public void Part2_ProducesCorrectResultFile4_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day08($"{_baseTestName}4.txt");
            instance.SecondResult.Should().Be(5);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}5.txt")]
        public void Part2_ProducesCorrectResultFile5_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day08($"{_baseTestName}5.txt");
            instance.SecondResult.Should().Be(19);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}6.txt")]
        public void Part2_ProducesCorrectResultFile6_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day08($"{_baseTestName}6.txt");
            instance.SecondResult.Should().Be(6);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}7.txt")]
        public void Part2_ProducesCorrectResultFile7_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day08($"{_baseTestName}7.txt");
            instance.SecondResult.Should().Be(6);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}8.txt")]
        public void Part2_ProducesCorrectResultFile8_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day08($"{_baseTestName}8.txt");
            instance.SecondResult.Should().Be(6);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}9.txt")]
        public void Part2_ProducesCorrectResultFile9_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day08($"{_baseTestName}9.txt");
            instance.SecondResult.Should().Be(5);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}10.txt")]
        public void Part2_ProducesCorrectResultFile10_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day08($"{_baseTestName}10.txt");
            instance.SecondResult.Should().Be(6);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}11.txt")]
        public void Part2_ProducesCorrectResultFile11_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day08($"{_baseTestName}11.txt");
            instance.SecondResult.Should().Be(7);
        }
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}12.txt")]
        public void Part2_ProducesCorrectResultFile12_IsTrue()
        {
            var instance = new AdventOfCode2015.Problems.Day08($"{_baseTestName}12.txt");
            instance.SecondResult.Should().Be(8);
        }
    }
}