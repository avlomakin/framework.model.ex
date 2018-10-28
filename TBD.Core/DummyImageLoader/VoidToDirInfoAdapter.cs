using System;
using System.IO;
using TBD.Model;

namespace TBD.Core
{
    public class VoidToDirInfoAdapter : IPipelineInputAdapter<DirectoryInfo>
    {
        public bool Enabled { get; set; }

        event PipelineDataReadyEventHandler<DirectoryInfo> OnOutputDataReadyInternal;

        event PipelineDataReadyEventHandler IAdapter.OnOutputDataReady
        {
            add => OnOutputDataReadyInternal += value.Invoke;
            remove => OnOutputDataReadyInternal -= value.Invoke;
        }

        public void InputDataReadyHandler( object sender, PipelineData data )
        {
            Console.WriteLine( "Void adapter" );
            OnOutputDataReadyInternal?.Invoke( this, new PipelineData<DirectoryInfo>() );
        }

        public event PipelineDataReadyEventHandler<DirectoryInfo> OnOutputDataReady
        {
            add => OnOutputDataReadyInternal += value;
            remove => OnOutputDataReadyInternal -= value;
        }
    }
}