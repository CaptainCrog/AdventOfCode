namespace AdventOfCode2024Tests
{
    [TestClass]
    public class Day14
    {
        const string _basePath = "Inputs/Day14";
        const string _baseTestName = "Day14Test";
        [TestMethod]
        [DeploymentItem($"{_basePath}/{_baseTestName}1.txt")]
        public void Part1_ProducesCorrectSafetyFactorAfter100Seconds_IsTrue()
        {
            var instance = new AdventOfCode2024.Problems.Day14("Day14Test1.txt", (7, 11));
            instance.FirstResult.Should().Be(12);
        }

        //PART 2 Generates a file which can be searched manually by finding a long list of '###############################' which represents the top/bottom of the picture

        //      ###############################
        //      #.............................#
        //      #.............................#
        //      #.............................#
        //      #.............................#
        //      #..............#..............#
        //      #.............###.............#
        //      #............#####............#
        //      #...........#######...........#
        //      #..........#########..........#
        //      #............#####............#
        //      #...........#######...........#
        //      #..........#########..........#
        //      #.........###########.........#
        //      #........#############........#
        //      #..........#########..........#
        //      #.........###########.........#
        //      #........#############........#
        //      #.......###############.......#
        //      #......#################......#
        //      #........#############........#
        //      #.......###############.......#
        //      #......#################......#
        //      #.....###################.....#
        //      #....#####################....#
        //      #.............###.............#
        //      #.............###.............#
        //      #.............###.............#
        //      #.............................#
        //      #.............................#
        //      #.............................#
        //      #.............................#
        //      ###############################
    }
}