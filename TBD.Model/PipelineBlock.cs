using System;

namespace TBD.Model
{
    public abstract class PipelineBlock
    {
        protected AdapterMap AdapterMap;
        public abstract IAdapter GetInterblockAdapter( Guid id );
    }
}