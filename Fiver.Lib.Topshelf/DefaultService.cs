using System;

namespace Fiver.Lib.Topshelf
{
    internal class DefaultService
    {
        public void Start(Action process)
        {
            process();
        }

        public void Stop(Action process)
        {
            process();
        }
    }
}
