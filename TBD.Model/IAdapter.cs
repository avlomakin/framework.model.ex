using System;

namespace TBD.Model
{
    public interface IAdapter 
    {
        Boolean Enabled { get; set; }

        event PipelineDataReadyEventHandler OnOutputDataReady;

        void InputDataReadyHandler( object sender, PipelineData data );
    }
}