namespace TBD.Model
{
    public interface IPipelineInputAdapter<TOutput> : IAdapter
    {
        new event PipelineDataReadyEventHandler<TOutput> OnOutputDataReady;
    }
}