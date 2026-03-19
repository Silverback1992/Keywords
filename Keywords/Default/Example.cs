using System;
using System.Collections.Generic;
using System.Text;

namespace Keywords.Default
{
    public class Example : IExample
    {
        public override void Process<T>(T value) where T : default
        {
            throw new NotImplementedException();
        }
    }
}
