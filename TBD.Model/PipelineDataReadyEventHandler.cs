namespace TBD.Model
{
    public delegate void PipelineDataReadyEventHandler( object sender, PipelineData data );

    public delegate void PipelineDataReadyEventHandler<TData>( object sender, PipelineData<TData> data );
}