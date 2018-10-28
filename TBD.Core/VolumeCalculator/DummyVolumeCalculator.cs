using System;
using TBD.Model;

namespace TBD.Core.VolumeCalculator
{
    public class DummyVolumeCalculator : IPipelineAlg<DummyImages, double>
    {
        public bool Enabled { get; set; }

        public event PipelineDataReadyEventHandler<double> OnOutputDataReady;

        public void InputDataReadyHandler( object sender, PipelineData<DummyImages> data )
        {
            OnOutputDataReady?.Invoke( this, new PipelineData<double> { Data = data.Data.A * 2 + data.Data.B * 3 } );
        }
    }
}