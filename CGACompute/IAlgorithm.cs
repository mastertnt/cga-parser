namespace CGACompute
{
    /// <summary>
    /// Interface for all algorithms
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface IAlgorithm<in TSource, out TResult>  : IGenericAlgorithm where TSource : class, new() where TResult : class, new()
    {
        TResult Compute(TSource pSource);
    }
}
