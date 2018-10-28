using System;
using TBD.Model;

namespace TBD.Core
{
    public class DummyImagesOutputAdapter : IPipelineOutputAdapter<DummyImages>
    {
        public bool Enabled { get; set; }

        private event PipelineDataReadyEventHandler OnOutputDataReadyInternal;

        public void InputDataReadyHandler( object sender, PipelineData data )
        {
            throw new Exception("Specify return type explicitly");
        }

        public void InputDataReadyHandler( object sender, PipelineData<DummyImages> data )
        {
            Console.WriteLine( $"Output dicom {data.Data.A}" );
            OnOutputDataReadyInternal?.Invoke( this, data );
        }

        public event PipelineDataReadyEventHandler OnOutputDataReady
        {
            add => OnOutputDataReadyInternal += value;
            remove => OnOutputDataReadyInternal -= value;
        }
    }
}