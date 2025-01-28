namespace CommonTypes.CommonTypes.Classes
{
    public abstract class DayBase
    {
        protected abstract string InputPath { get; set; }
        public abstract void InitialiseProblem();
        public abstract T SolveFirstProblem<T>() where T : IConvertible;
        public abstract T SolveSecondProblem<T>() where T : IConvertible;
        public abstract void OutputSolution();
    }
}
