using CommonTypes.CommonTypes.Classes;
using CommonTypes.CommonTypes.Enums;
using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;
using CommonTypes.CommonTypes.Regex;
using System.Diagnostics;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace AdventOfCode2017.Problems
{
    public class Day20 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        Regex _numberRegex = CommonRegexHelpers.NumberRegex();
        Dictionary<int, (Vector3 position, Vector3 velocity, Vector3 acceleration)> _particles = [];
        Dictionary<int, Queue<Vector3>> _particleStates = [];


        #endregion

        #region Properties

        public int FirstResult
        {
            get => _firstResult;
            set
            {
                if (_firstResult != value)
                {
                    _firstResult = value;
                }
            }
        }
        public int SecondResult
        {
            get => _secondResult;
            set
            {
                if (_secondResult != value)
                {
                    _secondResult = value;
                }
            }
        }
        #endregion

        #region Constructor
        public Day20(string inputPath) 
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods

        public void InitialiseProblem()
        {
            var input = File.ReadAllLines(_inputPath);
            for (int i = 0; i < input.Length; i++) 
            {
                var parts = input[i].Split('>', StringSplitOptions.TrimEntries);

                var positionNumbers = _numberRegex.Matches(parts[0]).Select(x => int.Parse(x.Value)).ToArray();
                Vector3 position = new(positionNumbers[0], positionNumbers[1], positionNumbers[2]);
                var velocityNumbers = _numberRegex.Matches(parts[1]).Select(x => int.Parse(x.Value)).ToArray();
                Vector3 velocity = new(velocityNumbers[0], velocityNumbers[1], velocityNumbers[2]);
                var accelerationNumbers = _numberRegex.Matches(parts[2]).Select(x => int.Parse(x.Value)).ToArray();
                Vector3 acceleration = new(accelerationNumbers[0], accelerationNumbers[1], accelerationNumbers[2]);

                _particles.Add(i, (position, velocity, acceleration));
            }

        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            var smallestManhattanDistance = float.MaxValue;
            var closestParticle = int.MaxValue;
            for (int i = 0; i < _particles.Count; i++)
            {
                var particle = _particles[i];
                var particleQueue = new Queue<Vector3>();
                particleQueue.Enqueue(particle.position);

                int iterator = 0;
                while (iterator != 1000)
                {
                    particle = ProcessParticle(particle);
                    particleQueue.Enqueue(particle.position);
                    iterator++;
                }

                var particlesManhattanDistance = GetManhattanDistance(particle.position);
                smallestManhattanDistance = Math.Min(smallestManhattanDistance, particlesManhattanDistance);
                if (particlesManhattanDistance == smallestManhattanDistance)
                    closestParticle = i;

                _particleStates.Add(i, particleQueue);
            }


            return (T)Convert.ChangeType(closestParticle, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            int iterator = 0;
            while (iterator != 1000)
            {
                var currentParticleState = _particleStates.Select(x => x.Value.Peek()).ToList();
                var collidedParticles = currentParticleState.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key).ToList();
                currentParticleState = currentParticleState.Where(x => !collidedParticles.Any(xx => x.Equals(xx))).ToList();
                _particleStates = _particleStates.Where(x => currentParticleState.Contains(x.Value.Peek())).ToDictionary(x => x.Key, x => x.Value);
                foreach (var queue in _particleStates.Values)
                {
                    queue.Dequeue();
                }

                iterator++;
            }

            return (T)Convert.ChangeType(_particleStates.Count, typeof(T));
        }

        (Vector3 position, Vector3 velocity, Vector3 acceleration) ProcessParticle((Vector3 position, Vector3 velocity, Vector3 acceleration) particle)
        {
            particle.velocity.X += particle.acceleration.X;
            particle.velocity.Y += particle.acceleration.Y; 
            particle.velocity.Z += particle.acceleration.Z;

            particle.position.X += particle.velocity.X;
            particle.position.Y += particle.velocity.Y;
            particle.position.Z += particle.velocity.Z;

            return particle;
        }

        float GetManhattanDistance(Vector3 position)
        {
            return Math.Abs(position.X) + Math.Abs(position.Y) + Math.Abs(position.Z);
        }

        #endregion
    }
}
