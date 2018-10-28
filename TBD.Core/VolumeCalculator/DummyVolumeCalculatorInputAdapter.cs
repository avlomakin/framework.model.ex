using System;
using TBD.Model;

namespace TBD.Core.VolumeCalculator
{
    public class DummyVolumeCalculatorInputAdapter : IPipelineInputAdapter<DummyImages>
    {
        public bool Enabled { get; set; }
        
        private event PipelineDataReadyEventHandler<DummyImages> OnOutputDataReadyInternal;

        public event PipelineDataReadyEventHandler<DummyImages> OnOutputDataReady
        {
            add => OnOutputDataReadyInternal += value;
            remove => OnOutputDataReadyInternal -= value;
        }

        event PipelineDataReadyEventHandler IAdapter.OnOutputDataReady
        {
            add => OnOutputDataReadyInternal += value.Invoke; 
            remove => OnOutputDataReadyInternal -= value.Invoke; 
        }

        public void InputDataReadyHandler( object sender, PipelineData data )
        {
            var dataEx = (data as PipelineData<DummyImages>)?.Data;
            Console.WriteLine( $"Input volume {dataEx?.A}" );

            var result = new PipelineData<DummyImages>
            {
                Data = dataEx
            };

            OnOutputDataReadyInternal?.Invoke( sender, result);
        }
    }
}