using System;

namespace TBD.Model
{
    public class PipelineData : EventArgs
    {
        public Object Data;
    }

    public class PipelineData<T> : PipelineData
    {
        public new T Data;
    }
}