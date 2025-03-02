namespace CommonTypes.CommonTypes.Interfaces
{
    public interface IDayBase
    {
        void InitialiseProblem();
        T SolveFirstProblem<T>() where T : IConvertible;
        T SolveSecondProblem<T>() where T : IConvertible;
        void OutputSolution();
    }
}
