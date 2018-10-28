using System;

namespace TBD.Model
{
    public interface IPipelineAlg
    {
        Boolean Enabled { get; set; }
    }

    public interface IPipelineAlg<T1, T2> : IPipelineAlg
    {
        event PipelineDataReadyEventHandler<T2> OnOutputDataReady;

        void InputDataReadyHandler( object sender, PipelineData<T1> data );
    }
}