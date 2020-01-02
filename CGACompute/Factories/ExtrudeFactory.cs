namespace CGACompute.Factories
{
    public class ExtrudeFactory : IAlgorithmFactory
    {
        public IGenericAlgorithm Create(CGAParser.Operation pOperation)
        {
            CGAParser.Extrude lExtrude = (CGAParser.Extrude) pOperation;
            return new CGACompute.Extrude(lExtrude.Distance, lExtrude.ExtrusionType);
        }
    }
}
