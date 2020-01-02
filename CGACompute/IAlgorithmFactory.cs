namespace CGACompute
{
    public interface IAlgorithmFactory
    {
        IGenericAlgorithm Create(CGAParser.Operation pOperation);
    }
}
