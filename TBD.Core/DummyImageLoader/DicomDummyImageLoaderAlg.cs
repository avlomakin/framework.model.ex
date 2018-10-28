using System;
using System.IO;
using TBD.Model;

namespace TBD.Core
{
    public class DicomDummyImageLoaderAlg : IPipelineAlg<DirectoryInfo, DummyImages>
    {
        public bool Enabled { get ; set ; }

        public event PipelineDataReadyEventHandler<DummyImages> OnOutputDataReady;

        public void InputDataReadyHandler(object sender, PipelineData<DirectoryInfo> data)
        {
            Console.WriteLine( "Image loader" );
            var result = new PipelineData<DummyImages>()
            {
                Data = new DummyImages()
            };

            OnOutputDataReady?.Invoke( this, result );
        }
    }

    
}
