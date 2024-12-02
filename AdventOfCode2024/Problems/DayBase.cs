using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Problems
{
    public abstract class DayBase
    {
        protected abstract string InputPath { get; set; }
        public abstract void InitialiseProblem();
        public abstract T SolveFirstProblem<T>() where T : struct;
        public abstract T SolveSecondProblem<T>() where T : struct;
        public abstract void OutputSolution();
    }
}
