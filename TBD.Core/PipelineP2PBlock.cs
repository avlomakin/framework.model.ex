using System;
using TBD.Model;

namespace TBD.Core
{
    public class PipelineP2PBlock : PipelineBlock
    {
        public IAdapter InputAdapter { get; set; }
        public IAdapter OutputAdapter { get; set; }
        public IPipelineAlg Alg { get; set; }

        public override IAdapter GetInterblockAdapter( Guid id )
        {
            throw new NotImplementedException();
        }
    }
}