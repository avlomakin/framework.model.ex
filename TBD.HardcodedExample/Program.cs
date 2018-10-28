using System;
using TBD.Core;
using TBD.Core.VolumeCalculator;
using TBD.Model;

namespace TBD.HardcodedExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var voidToDirInfoAdapter = new VoidToDirInfoAdapter();
            var dummyLoader = new DicomDummyImageLoaderAlg();
            var dummyImagesOutputAdapter = new DummyImagesOutputAdapter();

            voidToDirInfoAdapter.OnOutputDataReady += dummyLoader.InputDataReadyHandler;
            dummyLoader.OnOutputDataReady += dummyImagesOutputAdapter.InputDataReadyHandler;

            PipelineP2PBlock block = new PipelineP2PBlock()
            {
                InputAdapter = voidToDirInfoAdapter,
                Alg = dummyLoader,
                OutputAdapter = dummyImagesOutputAdapter
            };

            DummyVolumeCalculatorInputAdapter volumeCalculatorInputAdapter = new DummyVolumeCalculatorInputAdapter();
            DummyVolumeCalculator volumeCalculator = new DummyVolumeCalculator();

            block.OutputAdapter.OnOutputDataReady += volumeCalculatorInputAdapter.InputDataReadyHandler;
            volumeCalculatorInputAdapter.OnOutputDataReady += volumeCalculator.InputDataReadyHandler;

            volumeCalculator.OnOutputDataReady += PrintVolumeCalcResult;

            //run the pipeline;
            voidToDirInfoAdapter.InputDataReadyHandler( null, new PipelineData() );
            Console.ReadLine();
        }

        private static void PrintVolumeCalcResult(object sender, Model.PipelineData<double> data)
        {
            Console.WriteLine( data.Data );
            Console.ReadLine();
        }
    }
}
