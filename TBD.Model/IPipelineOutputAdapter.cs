namespace TBD.Model
{
    public interface IPipelineOutputAdapter<TInput> : IAdapter
    {

        void InputDataReadyHandler( object sender, PipelineData<TInput> data );
    }
}